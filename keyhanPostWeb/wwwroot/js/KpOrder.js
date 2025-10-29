// Modal Functions
function openOrderModal() {
    document.getElementById('orderModal').classList.add('show');
    resetForm();
}

function closeModal() {
    document.getElementById('orderModal').classList.remove('show');
}

function closeSuccessModal() {
    document.getElementById('successModal').classList.remove('show');
}

// Form Navigation
let currentStep = 1;
const totalSteps = 4;

function showStep(step) {
    // Hide all steps
    document.querySelectorAll('.form-step').forEach(s => {
        s.classList.remove('active');
    });

    // Show current step
    document.getElementById('step' + step).classList.add('active');

    // Update progress bar
    const progress = ((step - 1) / (totalSteps - 1)) * 100;
    document.getElementById('progressBar').style.width = progress + '%';

    // Update step indicators
    for (let i = 1; i <= totalSteps; i++) {
        const indicator = document.getElementById('step' + i + 'Indicator');
        const title = document.getElementById('step' + i + 'Title');

        if (i < step) {
            indicator.className = 'step-indicator completed';
            title.className = 'step-title completed';
        } else if (i === step) {
            indicator.className = 'step-indicator active';
            title.className = 'step-title active';
        } else {
            indicator.className = 'step-indicator inactive';
            title.className = 'step-title';
        }
    }

    currentStep = step;
}

function nextStep() {
    if (currentStep < totalSteps) {
        // Validate current step
        if (validateStep(currentStep)) {
            showStep(currentStep + 1);

            // Update summary if moving to final step
            if (currentStep + 1 === totalSteps) {
                updateSummary();
            }
        }
    }
}

function prevStep() {
    if (currentStep > 1) {
        showStep(currentStep - 1);
    }
}

// Package Type Selection
function selectPackageType(type, element) {
    // Remove selection from all cards
    document.querySelectorAll('.package-type-card').forEach(card => {
        card.classList.remove('selected');
    });

    // Add selection to clicked card
    element.classList.add('selected');

    // Enable next button
    document.getElementById('nextBtn1').disabled = false;

    // Store selected package type
    document.getElementById('orderForm').dataset.packageType = type;
}

// Validate Step
function validateStep(step) {
    const form = document.getElementById('orderForm');
    let isValid = true;
    if (step === 1) {
        // Check if package type is selected
        if (!form.dataset.packageType) {
            isValid = false;
            alert('لطفاً نوع بسته را انتخاب کنید');
        }
    } else if (step === 2) {
        // Validate package details
        const origin = document.getElementById('origin').value;
        const destination = document.getElementById('destination').value;
        const length = document.getElementById('length').value;
        const width = document.getElementById('width').value;
        const height = document.getElementById('height').value;
        const weight = document.getElementById('actual-weight').value;
        if (!origin || !destination) {
            isValid = false;
            alert('لطفاً مبدا و مقصد را انتخاب کنید');
        } else if (!length || !width || !height || !weight) {
            isValid = false;
            alert('لطفاً تمام ابعاد و وزن را وارد کنید');
        } else if (parseFloat(weight) <= 0) {
            isValid = false;
            alert('وزن باید بیشتر از صفر باشد');
        }
    } else if (step === 3) {
        // Validate sender information
        const senderName = document.getElementById('sender-name').value;
        const senderPhone = document.getElementById('sender-phone').value;
        const senderAddress = document.getElementById('sender-address').value;

        if (!senderName || !senderPhone || !senderAddress) {
            isValid = false;
            alert('لطفاً تمام اطلاعات فرستنده را وارد کنید');
        } else if (senderPhone.length !== 11 || !senderPhone.startsWith('09')) {
            isValid = false;
            alert('شماره تماس فرستنده باید 11 رقم و با 09 شروع شود');
        }

        // Validate receiver information
        const receiverName = document.getElementById('receiver-name').value;
        const receiverPhone = document.getElementById('receiver-phone').value;
        const receiverAddress = document.getElementById('receiver-address').value;

        if (!receiverName || !receiverPhone || !receiverAddress) {
            isValid = false;
            alert('لطفاً تمام اطلاعات گیرنده را وارد کنید');
        } else if (receiverPhone.length !== 11 || !receiverPhone.startsWith('09')) {
            isValid = false;
            alert('شماره تماس گیرنده باید 11 رقم و با 09 شروع شود');
        }
    }
    return isValid;
}


// Copy Sender Info to Receiver
function copySenderInfo() {
    const checkbox = document.getElementById('same-as-sender');
    if (checkbox.checked) {
        document.getElementById('receiver-name').value = document.getElementById('sender-name').value;
        document.getElementById('receiver-phone').value = document.getElementById('sender-phone').value;
        document.getElementById('receiver-address').value = document.getElementById('sender-address').value;
    }
}
// Update Summary
function updateSummary() {
    // Get package type
    const packageType = document.getElementById('orderForm').dataset.packageType;
    let packageTypeText = '';
    switch (packageType) {
        case 'regular':
            packageTypeText = 'کالای عادی';
            break;
        case 'electronic':
            packageTypeText = 'کالای الکترونیکی';
            break;
        case 'envelope':
            packageTypeText = 'پاکت';
            break;
    }
    document.getElementById('summary-package-type').textContent = packageTypeText;

    // Get package details
    document.getElementById('summary-origin').textContent = document.getElementById('origin').value;
    document.getElementById('summary-destination').textContent = document.getElementById('destination').value;
    document.getElementById('summary-dimensions').textContent =
        `${document.getElementById('length').value} × ${document.getElementById('width').value} × ${document.getElementById('height').value} سانتی‌متر`;
    document.getElementById('summary-weight').textContent = document.getElementById('actual-weight').value + ' کیلوگرم';

    // Generate random tracking code
    const trackingCode = Math.floor(100000 + Math.random() * 900000);
    document.getElementById('tracking-code').textContent = trackingCode;
    document.getElementById('success-tracking-code').textContent = trackingCode;

    // Get sender info
    document.getElementById('summary-sender-name').textContent = document.getElementById('sender-name').value;
    document.getElementById('summary-sender-phone').textContent = document.getElementById('sender-phone').value;
    document.getElementById('summary-sender-email').textContent = document.getElementById('sender-email').value || 'ندارد';
    document.getElementById('summary-sender-address').textContent = document.getElementById('sender-address').value;

    // Get receiver info
    document.getElementById('summary-receiver-name').textContent = document.getElementById('receiver-name').value;
    document.getElementById('summary-receiver-phone').textContent = document.getElementById('receiver-phone').value;
    document.getElementById('summary-receiver-email').textContent = document.getElementById('receiver-email').value || 'ندارد';
    document.getElementById('summary-receiver-address').textContent = document.getElementById('receiver-address').value;
}

// Form Submission
document.getElementById('orderForm').addEventListener('submit', function (e) {
    e.preventDefault();

    if (validateStep(currentStep)) {
        // Close order modal
        closeModal();

        // Show success modal after a short delay
        setTimeout(() => {
            document.getElementById('successModal').classList.add('show');
        }, 500);
    }
});

// Print Receipt
function printReceipt() {
    alert('در حال چاپ رسید...');
}

// Track Shipment
function trackShipment() {
    alert('در حال انتقال به صفحه پیگیری مرسوله...');
}

// Share Tracking
function shareTracking() {
    alert('در حال اشتراک‌گذاری لینک پیگیری...');
}

// Reset Form
function resetForm() {
    // Reset form data
    delete document.getElementById('orderForm').dataset.packageType;

    // Reset form fields
    document.getElementById('orderForm').reset();

    // Reset package type selection
    document.querySelectorAll('.package-type-card').forEach(card => {
        card.classList.remove('selected');
    });

    // Reset same as sender checkbox
    document.getElementById('same-as-sender').checked = false;

    // Reset progress to first step
    showStep(1);
}

// Close modals when clicking outside
window.addEventListener('click', function (e) {
    const orderModal = document.getElementById('orderModal');
    const successModal = document.getElementById('successModal');

    if (e.target === orderModal) {
        closeModal();
    }
    if (e.target === successModal) {
        closeSuccessModal();
    }
});

// Initialize
showStep(1);
