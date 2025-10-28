// Slider functionality
let slideIndex = 1;
let slideInterval;

function showSlides(n) {
    const slides = document.querySelectorAll('.slide');
    const dots = document.querySelectorAll('.slider-dot');

    if (n > slides.length) { slideIndex = 1; }
    if (n < 1) { slideIndex = slides.length; }

    slides.forEach(slide => {
        slide.style.opacity = '0';
        slide.classList.remove('active');
    });

    dots.forEach(dot => {
        dot.classList.remove('opacity-100');
        dot.classList.add('opacity-50');
    });

    slides[slideIndex - 1].style.opacity = '1';
    slides[slideIndex - 1].classList.add('active');
    dots[slideIndex - 1].classList.remove('opacity-50');
    dots[slideIndex - 1].classList.add('opacity-100');
}

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function autoSlide() {
    slideIndex++;
    showSlides(slideIndex);
}

// Initialize slider
document.addEventListener('DOMContentLoaded', function () {
    showSlides(slideIndex);
    slideInterval = setInterval(autoSlide, 5000);
});
const mobileBtn = document.getElementById('mobile-menu-btn');
const mobileMenu = document.getElementById('mobile-menu');

mobileBtn.addEventListener('click', () => {
    mobileMenu.classList.toggle('hidden');
});
// Pause auto-slide on hover
document.querySelector('.slider-container').addEventListener('mouseenter', function () {
    clearInterval(slideInterval);
});

document.querySelector('.slider-container').addEventListener('mouseleave', function () {
    slideInterval = setInterval(autoSlide, 5000);
});

// Mobile menu functionality
document.getElementById('mobile-menu-btn').addEventListener('click', function () {
    const mobileMenu = document.getElementById('mobile-menu');
    const icon = this.querySelector('i');

    if (mobileMenu.classList.contains('hidden')) {
        mobileMenu.classList.remove('hidden');
        icon.classList.remove('fa-bars');
        icon.classList.add('fa-times');
    } else {
        mobileMenu.classList.add('hidden');
        icon.classList.remove('fa-times');
        icon.classList.add('fa-bars');
    }
});

// Close mobile menu when clicking on links
document.querySelectorAll('#mobile-menu a').forEach(link => {
    link.addEventListener('click', function () {
        document.getElementById('mobile-menu').classList.add('hidden');
        document.querySelector('#mobile-menu-btn i').classList.remove('fa-times');
        document.querySelector('#mobile-menu-btn i').classList.add('fa-bars');
    });
});

// Scroll to section function
function scrollToSection(sectionId) {
    const element = document.getElementById(sectionId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}

// Cost Calculator with validation
function calculateCost() {
    const packageType = document.getElementById('package-type').value;
    const length = document.getElementById('length').value;
    const width = document.getElementById('width').value;
    const height = document.getElementById('height').value;
    const weight = document.getElementById('actual-weight').value;

    // Basic validation
    if (!length || !width || !height || !weight) {
        alert('لطفاً تمام فیلدها را تکمیل کنید');
        return;
    }

    if (length <= 0 || width <= 0 || height <= 0 || weight <= 0) {
        alert('مقادیر وارد شده باید بیشتر از صفر باشند');
        return;
    }

    document.getElementById('cost-result').classList.remove('hidden');
}

// Animated progress bar for shipping steps
function animateProgress(step) {
    const progressBar = document.querySelector('.progress-bar');
    const percentage = (step / 4) * 100;
    progressBar.style.width = percentage + '%';

    // Reset after 3 seconds
    setTimeout(() => {
        progressBar.style.width = '0%';
    }, 3000);
}

// Auto-animate progress on page load
window.addEventListener('load', function () {
    setTimeout(() => animateProgress(4), 1000);
});

// Province Map Interaction
document.querySelectorAll('.province').forEach(province => {
    province.addEventListener('mouseenter', function (e) {
        const tooltip = document.getElementById('province-tooltip');
        const provinceName = this.getAttribute('data-province');
        const rep = this.getAttribute('data-rep');

        document.getElementById('province-name').textContent = provinceName;
        document.getElementById('province-rep').textContent = 'نماینده: ' + rep;

        tooltip.classList.remove('hidden');
        tooltip.style.left = e.pageX + 10 + 'px';
        tooltip.style.top = e.pageY - 50 + 'px';
    });

    province.addEventListener('mouseleave', function () {
        document.getElementById('province-tooltip').classList.add('hidden');
    });
});

// Contract Verification
function verifyContract() {
    alert('کد اعتباری: AC-2024-' + Math.floor(Math.random() * 10000) + '\nاحراز هویت با موفقیت انجام شد.');
}

// Send Message
function sendMessage() {
    alert('پیام شما با موفقیت ارسال شد. کارشناس مربوطه در اسرع وقت پاسخ خواهد داد.');
}


// Tracking Functions
// Tracking Functions
function trackDomesticShipment() {
    const trackingCode = document.getElementById('domestic-tracking-code').value;
    if (!trackingCode) {
        alert('لطفاً کد رهگیری داخلی را وارد کنید.');
        return;
    }

    // Show shipment details
    document.getElementById('shipment-details').classList.remove('hidden');

    // Scroll to details
    document.getElementById('shipment-details').scrollIntoView({
        behavior: 'smooth',
        block: 'start'
    });
}

function trackInternationalShipment() {
    const trackingCode = document.getElementById('international-tracking-code').value;
    if (!trackingCode) {
        alert('لطفاً کد رهگیری بین‌المللی را وارد کنید.');
        return;
    }

    // Simulate international tracking
    alert('در حال اتصال به سیستم پیگیری بین‌المللی...\nکد رهگیری: ' + trackingCode + '\n\nاین قابلیت به‌زودی کامل خواهد شد.');
}

function openInternationalTracking() {
    alert('سایت پیگیری بین‌المللی در حال بارگذاری...\nشما به سایت رسمی اتحادیه پستی جهانی هدایت خواهید شد.');
}

// Legacy function for backward compatibility
function trackShipment() {
    trackDomesticShipment();
}

function printReceipt() {
    alert('رسید در حال چاپ است...\nاین قابلیت به‌زودی کامل خواهد شد.');
}

function downloadPDF() {
    alert('فایل PDF در حال دانلود است...\nاین قابلیت به‌زودی کامل خواهد شد.');
}

function shareTracking() {
    if (navigator.share) {
        navigator.share({
            title: 'پیگیری مرسوله - پست سریع ایران',
            text: 'کد رهگیری: IR-2024-123456',
            url: window.location.href
        });
    } else {
        // Fallback for browsers that don't support Web Share API
        const url = window.location.href + '?track=IR-2024-123456';
        navigator.clipboard.writeText(url).then(() => {
            alert('لینک پیگیری کپی شد!');
        });
    }
}

// Representative Page Function
function openRepresentativePage() {
    // Create representative page content
    const representativePage = `
                <!DOCTYPE html>
                <html lang="fa" dir="rtl">
                <head>
                    <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>درخواست نمایندگی - کیهان پست</title>
                    <script src="https://cdn.tailwindcss.com"></script>
                    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet">
                    <style>
                        @import url('https://fonts.googleapis.com/css2?family=Vazirmatn:wght@300;400;500;600;700&display=swap');
                        * { font-family: 'Vazirmatn', sans-serif; }
                    </style>
                </head>
                <body class="bg-gray-50">
                    <div class="min-h-screen py-12">
                        <div class="container mx-auto px-4 max-w-4xl">
                            <div class="bg-white rounded-2xl shadow-lg p-8">
                                <div class="text-center mb-8">
                                    <div class="bg-blue-600 text-white p-4 rounded-full w-20 h-20 flex items-center justify-center mx-auto mb-4">
                                        <i class="fas fa-handshake text-3xl"></i>
                                    </div>
                                    <h1 class="text-3xl font-bold text-gray-800 mb-2">درخواست نمایندگی</h1>
                                    <p class="text-gray-600">به خانواده بزرگ پست سریع ایران بپیوندید</p>
                                </div>
                                
                                <form class="space-y-6">
                                    <div class="grid md:grid-cols-2 gap-6">
                                        <div>
                                            <label class="block text-gray-700 font-medium mb-2">نام و نام خانوادگی</label>
                                            <input type="text" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500">
                                        </div>
                                        <div>
                                            <label class="block text-gray-700 font-medium mb-2">کد ملی</label>
                                            <input type="text" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500">
                                        </div>
                                    </div>
                                    
                                    <div class="grid md:grid-cols-2 gap-6">
                                        <div>
                                            <label class="block text-gray-700 font-medium mb-2">شماره موبایل</label>
                                            <input type="tel" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500">
                                        </div>
                                        <div>
                                            <label class="block text-gray-700 font-medium mb-2">ایمیل</label>
                                            <input type="email" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500">
                                        </div>
                                    </div>
                                    
                                    <div>
                                        <label class="block text-gray-700 font-medium mb-2">آدرس</label>
                                         <input type="text" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500">
                                      
                                    </div>
                                    
                                    <div>
                                        <label class="block text-gray-700 font-medium mb-2">سابقه کاری</label>
                                        <textarea rows="4" placeholder="سابقه کاری خود در زمینه حمل و نقل یا خدمات مشابه را شرح دهید" class="w-full p-4 border border-gray-300 rounded-xl focus:ring-2 focus:ring-blue-500"></textarea>
                                    </div>
                                    
                                   
                                    
                                    <div class="bg-blue-50 border border-blue-200 rounded-xl p-6">
                                        <h3 class="font-semibold text-blue-800 mb-3">مزایای نمایندگی:</h3>
                                        <ul class="space-y-2 text-blue-700">
                                            <li class="flex items-center"><i class="fas fa-check text-green-600 ml-2"></i> دریافت کمیسیون از هر مرسوله</li>
                                            <li class="flex items-center"><i class="fas fa-check text-green-600 ml-2"></i> آموزش کامل سیستم</li>
                                            <li class="flex items-center"><i class="fas fa-check text-green-600 ml-2"></i> پشتیبانی 24 ساعته</li>
                                            <li class="flex items-center"><i class="fas fa-check text-green-600 ml-2"></i> تجهیزات و نرم‌افزار رایگان</li>
                                        </ul>
                                    </div>
                                    
                                    <button type="submit" class="w-full bg-gradient-to-r from-blue-600 to-green-600 text-white py-4 rounded-xl font-medium hover:shadow-lg transition-all">
                                        ارسال درخواست نمایندگی
                                    </button>
                                </form>
                                
                                <div class="mt-8 text-center">
                                    <button onclick="window.close()" class="text-gray-600 hover:text-gray-800 transition-colors">
                                        <i class="fas fa-arrow-right ml-2"></i>
                                        بازگشت به صفحه اصلی
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                <script>(function(){function c(){var b=a.contentDocument||a.contentWindow.document;if(b){var d=b.createElement('script');d.innerHTML="window.__CF$cv$params={r:'9662dd40f3b22f2b',t:'MTc1MzY4OTg1MS4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);";b.getElementsByTagName('head')[0].appendChild(d)}}if(document.body){var a=document.createElement('iframe');a.height=1;a.width=1;a.style.position='absolute';a.style.top=0;a.style.left=0;a.style.border='none';a.style.visibility='hidden';document.body.appendChild(a);if('loading'!==document.readyState)c();else if(window.addEventListener)document.addEventListener('DOMContentLoaded',c);else{var e=document.onreadystatechange||function(){};document.onreadystatechange=function(b){e(b);'loading'!==document.readyState&&(document.onreadystatechange=e,c())}}}})();</script></body>
                </html>
            `;

    const newWindow = window.open('', '_blank', 'width=1000,height=800,scrollbars=yes');
    newWindow.document.write(representativePage);
    newWindow.document.close();
}

// Blog Page Function
function openBlogPage() {
    // Create blog page content
    const blogPage = `
                <!DOCTYPE html>
                <html lang="fa" dir="rtl">
                <head>
                    <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>وبلاگ - پست سریع ایران</title>
                    <script src="https://cdn.tailwindcss.com"></script>
                    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet">
                    <style>
                        @import url('https://fonts.googleapis.com/css2?family=Vazirmatn:wght@300;400;500;600;700&display=swap');
                        * { font-family: 'Vazirmatn', sans-serif; }
                    </style>
                </head>
                <body class="bg-gray-50">
                    <div class="min-h-screen py-12">
                        <div class="container mx-auto px-4 max-w-6xl">
                            <div class="text-center mb-12">
                                <h1 class="text-4xl font-bold text-gray-800 mb-4">وبلاگ پست سریع ایران</h1>
                                <p class="text-gray-600 max-w-2xl mx-auto">آخرین اخبار، راهنماها و نکات مفید در زمینه حمل و نقل</p>
                            </div>
                            
                            <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-8">
                                <!-- Blog posts would be dynamically loaded here -->
                                <div class="bg-white rounded-xl shadow-lg overflow-hidden">
                                    <div class="bg-gradient-to-br from-blue-500 to-blue-600 h-48 flex items-center justify-center">
                                        <i class="fas fa-shipping-fast text-6xl text-white opacity-50"></i>
                                    </div>
                                    <div class="p-6">
                                        <h3 class="text-xl font-bold mb-3">نحوه محاسبه هزینه ارسال بین‌المللی</h3>
                                        <p class="text-gray-600 mb-4">راهنمای کامل برای محاسبه هزینه ارسال مرسولات به خارج از کشور...</p>
                                        <div class="flex items-center justify-between">
                                            <span class="text-sm text-gray-500">15 آذر 1403</span>
                                            <a href="#" class="text-blue-600 hover:text-blue-700">ادامه مطلب</a>
                                        </div>
                                    </div>
                                </div>
                                
                                <!-- More blog posts... -->
                            </div>
                            
                            <div class="mt-12 text-center">
                                <button onclick="window.close()" class="bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition-colors">
                                    <i class="fas fa-arrow-right ml-2"></i>
                                    بازگشت به صفحه اصلی
                                </button>
                            </div>
                        </div>
                    </div>
                </body>
                </html>
            `;

    const newWindow = window.open('', '_blank', 'width=1200,height=800,scrollbars=yes');
    newWindow.document.write(blogPage);
    newWindow.document.close();
}

// Blog Functions
function openBlogPost(postId) {
    const posts = {
        1: 'نحوه محاسبه هزینه ارسال بین‌المللی',
        2: 'راهنمای بسته‌بندی صحیح کالاها',
        3: 'آمار و روند رشد صنعت پست در ایران'
    };
    alert('در حال باز کردن مقاله: ' + posts[postId] + '\n\nاین قابلیت به‌زودی اضافه خواهد شد.');
}

function filterBlog(category) {
    // Update active filter button
    document.querySelectorAll('.blog-filter').forEach(btn => {
        btn.classList.remove('active', 'bg-blue-600', 'text-white');
        btn.classList.add('bg-gray-200', 'text-gray-700');
    });

    event.target.classList.add('active', 'bg-blue-600', 'text-white');
    event.target.classList.remove('bg-gray-200', 'text-gray-700');

    // Filter logic would go here in a real implementation
    alert('فیلتر ' + category + ' اعمال شد. این قابلیت به‌زودی کامل خواهد شد.');
}

function subscribeNewsletter() {
    const email = event.target.previousElementSibling.value;
    if (!email) {
        alert('لطفاً ایمیل خود را وارد کنید.');
        return;
    }
    if (!email.includes('@')) {
        alert('لطفاً ایمیل معتبر وارد کنید.');
        return;
    }
    alert('با تشکر! شما با موفقیت در خبرنامه عضو شدید.');
    event.target.previousElementSibling.value = '';
}

// Smooth scrolling for navigation links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});
// Mobile menu functionality
document.getElementById('mobile-menu-btn').addEventListener('click', function () {
    const mobileMenu = document.getElementById('mobile-menu');
    const icon = this.querySelector('i');
    if (mobileMenu.classList.contains('hidden')) {
        mobileMenu.classList.remove('hidden');
        icon.classList.remove('fa-bars');
        icon.classList.add('fa-times');
    } else {
        mobileMenu.classList.add('hidden');
        icon.classList.remove('fa-times');
        icon.classList.add('fa-bars');
    }
});

// Close mobile menu when clicking on links
document.querySelectorAll('#mobile-menu a').forEach(link => {
    link.addEventListener('click', function () {
        document.getElementById('mobile-menu').classList.add('hidden');
        document.querySelector('#mobile-menu-btn i').classList.remove('fa-times');
        document.querySelector('#mobile-menu-btn i').classList.add('fa-bars');
    });
});

// Scroll to section function
function scrollToSection(sectionId) {
    const element = document.getElementById(sectionId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}

// Province Map Interaction
document.querySelectorAll('.province').forEach(province => {
    province.addEventListener('mouseenter', function (e) {
        const tooltip = document.getElementById('province-tooltip');
        const provinceName = this.getAttribute('data-province');
        const rep = this.getAttribute('data-rep');
        const address = this.getAttribute('data-address') || '';
        const phone = this.getAttribute('data-phone') || '';

        document.getElementById('province-name').textContent = provinceName;
        document.getElementById('province-rep').textContent = 'نماینده: ' + rep;

        if (address) {
            document.getElementById('province-address').textContent = 'آدرس: ' + address;
            document.getElementById('province-address').style.display = 'block';
        } else {
            document.getElementById('province-address').style.display = 'none';
        }

        if (phone) {
            document.getElementById('province-phone').textContent = 'تلفن: ' + phone;
            document.getElementById('province-phone').style.display = 'block';
        } else {
            document.getElementById('province-phone').style.display = 'none';
        }

        tooltip.classList.remove('hidden');
        tooltip.style.left = e.pageX + 10 + 'px';
        tooltip.style.top = e.pageY - 50 + 'px';
    });

    province.addEventListener('mousemove', function (e) {
        const tooltip = document.getElementById('province-tooltip');
        if (!tooltip.classList.contains('hidden')) {
            tooltip.style.left = e.pageX + 10 + 'px';
            tooltip.style.top = e.pageY - 50 + 'px';
        }
    });

    province.addEventListener('mouseleave', function () {
        document.getElementById('province-tooltip').classList.add('hidden');
    });

    // Click to show branch details
    province.addEventListener('click', function () {
        const provinceName = this.getAttribute('data-province');
        const rep = this.getAttribute('data-rep');
        const address = this.getAttribute('data-address') || '';
        const phone = this.getAttribute('data-phone') || '';

        if (rep !== 'به‌زودی') {
            document.getElementById('detail-address').textContent = address;
            document.getElementById('detail-phone').textContent = phone;
            document.getElementById('detail-rep').textContent = rep;

            document.getElementById('branch-details').classList.remove('hidden');
            document.getElementById('branch-details').scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Contract Verification
function verifyContract() {
    alert('کد اعتباری: AC-2024-' + Math.floor(Math.random() * 10000) + '\nاحراز هویت با موفقیت انجام شد.');
}



// Search Branches
function searchBranches() {
    const province = document.getElementById('province-search').value;
    const city = document.getElementById('city-search').value;

    if (!province && !city) {
        alert('لطفاً حداقل یکی از فیلدهای جستجو را پر کنید.');
        return;
    }

    // In a real implementation, this would filter the map and branches
    alert('جستجو برای ' + (province !== 'همه استان‌ها' ? province : '') + ' ' + city + ' انجام شد.\nاین قابلیت در نسخه کامل پیاده‌سازی خواهد شد.');
}



// Smooth scrolling for navigation links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});
// Smooth scrolling for navigation links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Shipping Order Form Functionality
document.addEventListener('DOMContentLoaded', function () {
    // Generate unique form number
    const formNumber = 'FR-' + new Date().getFullYear() + '-' + String(Math.floor(Math.random() * 10000)).padStart(3, '0');
    document.getElementById('formNumber').textContent = formNumber;

    // Form submission handler
    const shippingForm = document.getElementById('shippingOrderForm');
    if (shippingForm) {
        shippingForm.addEventListener('submit', function (e) {
            e.preventDefault();
            handleShippingOrderSubmission();
        });
    }
});

function handleShippingOrderSubmission() {
    // Validate required fields
    const requiredFields = [
        'customerName',
        'customerPhone',
        'deliveryAddress',
        'cargoType',
        'cargoWeight',
        'pickupAddress',
        'finalDeliveryAddress',
        'vehicleType'
    ];

    let isValid = true;
    let firstInvalidField = null;

    requiredFields.forEach(fieldId => {
        const field = document.getElementById(fieldId);
        if (!field.value.trim()) {
            field.classList.add('border-red-500', 'bg-red-50');
            field.classList.remove('border-gray-300');
            if (!firstInvalidField) {
                firstInvalidField = field;
            }
            isValid = false;
        } else {
            field.classList.remove('border-red-500', 'bg-red-50');
            field.classList.add('border-gray-300');
        }
    });

    // Check terms acceptance
    const acceptTerms = document.getElementById('acceptTerms');
    if (!acceptTerms.checked) {
        alert('لطفاً شرایط و قوانین را بپذیرید.');
        acceptTerms.focus();
        return;
    }

    if (!isValid) {
        alert('لطفاً تمام فیلدهای اجباری را تکمیل کنید.');
        if (firstInvalidField) {
            firstInvalidField.scrollIntoView({ behavior: 'smooth', block: 'center' });
            firstInvalidField.focus();
        }
        return;
    }

    // Validate phone number format
    const phoneNumber = document.getElementById('customerPhone').value;
    const phoneRegex = /^09\d{9}$/;
    if (!phoneRegex.test(phoneNumber)) {
        alert('لطفاً شماره موبایل را به صورت صحیح وارد کنید (مثال: 09123456789)');
        document.getElementById('customerPhone').focus();
        return;
    }

    // Validate email if provided
    const email = document.getElementById('customerEmail').value;
    if (email && !email.includes('@')) {
        alert('لطفاً آدرس ایمیل را به صورت صحیح وارد کنید.');
        document.getElementById('customerEmail').focus();
        return;
    }

    // Validate weight
    const weight = parseFloat(document.getElementById('cargoWeight').value);
    if (weight <= 0) {
        alert('وزن بار باید بیشتر از صفر باشد.');
        document.getElementById('cargoWeight').focus();
        return;
    }

    // Show loading state
    const submitButton = document.querySelector('button[type="submit"]');
    const originalText = submitButton.innerHTML;
    submitButton.innerHTML = '<i class="fas fa-spinner fa-spin ml-3"></i>در حال ثبت سفارش...';
    submitButton.disabled = true;

    // Simulate API call
    setTimeout(() => {
        // Generate tracking number
        const trackingNumber = 'ORD-' + new Date().getFullYear() + '-' + String(Math.floor(Math.random() * 100000)).padStart(5, '0');
        document.getElementById('orderTrackingNumber').textContent = trackingNumber;

        // Hide form and show success message
        document.getElementById('shippingOrderForm').parentElement.style.display = 'none';
        document.getElementById('orderSummary').classList.remove('hidden');

        // Scroll to success message
        document.getElementById('orderSummary').scrollIntoView({
            behavior: 'smooth',
            block: 'start'
        });

        // Reset button
        submitButton.innerHTML = originalText;
        submitButton.disabled = false;

        // Show success notification
        showNotification('سفارش شما با موفقیت ثبت شد!', 'success');

    }, 2000);
}

// Show notification function
function showNotification(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = `fixed top-4 right-4 z-50 p-4 rounded-lg shadow-lg max-w-sm transform transition-all duration-300 translate-x-full`;

    if (type === 'success') {
        notification.classList.add('bg-green-600', 'text-white');
        notification.innerHTML = `<i class="fas fa-check-circle ml-2"></i>${message}`;
    } else if (type === 'error') {
        notification.classList.add('bg-red-600', 'text-white');
        notification.innerHTML = `<i class="fas fa-exclamation-circle ml-2"></i>${message}`;
    } else {
        notification.classList.add('bg-blue-600', 'text-white');
        notification.innerHTML = `<i class="fas fa-info-circle ml-2"></i>${message}`;
    }

    document.body.appendChild(notification);

    // Animate in
    setTimeout(() => {
        notification.classList.remove('translate-x-full');
    }, 100);

    // Animate out and remove
    setTimeout(() => {
        notification.classList.add('translate-x-full');
        setTimeout(() => {
            document.body.removeChild(notification);
        }, 300);
    }, 4000);
}

// Add navigation link to shipping order form
function addShippingOrderNavigation() {
    // Add to desktop navigation
    //const desktopNav = document.querySelector('nav.hidden.md\\:flex');
    //if (desktopNav) {
    //    const shippingOrderLink = document.createElement('a');
    //    shippingOrderLink.href = '#shipping-order';
    //    shippingOrderLink.className = 'hover:text-green-300 transition-colors';
        
    //    desktopNav.appendChild(shippingOrderLink);
    //}

    //// Add to mobile navigation
    //const mobileNav = document.querySelector('#mobile-menu nav');
    //if (mobileNav) {
    //    const mobileShippingOrderLink = document.createElement('a');
    //    mobileShippingOrderLink.href = '#shipping-order';
    //    mobileShippingOrderLink.className = 'text-white hover:text-green-300 transition-colors py-2';
    //    mobileShippingOrderLink.textContent = 'سفارش حمل بار';
    //    mobileNav.appendChild(mobileShippingOrderLink);
    //}
}

// Initialize shipping order navigation
document.addEventListener('DOMContentLoaded', function () {
    addShippingOrderNavigation();
});

// Form field validation on blur
document.addEventListener('DOMContentLoaded', function () {
    const requiredFields = document.querySelectorAll('#shippingOrderForm [required]');ر

    requiredFields.forEach(field => {
        field.addEventListener('blur', function () {
            if (!this.value.trim()) {
                this.classList.add('border-red-500', 'bg-red-50');
                this.classList.remove('border-gray-300');
            } else {
                this.classList.remove('border-red-500', 'bg-red-50');
                this.classList.add('border-gray-300');
            }
        });

        field.addEventListener('input', function () {
            if (this.value.trim()) {
                this.classList.remove('border-red-500', 'bg-red-50');
                this.classList.add('border-gray-300');
            }
        });
    });
});
function openQuickOrder() {
    // Create quick order modal
    const quickOrderModal = document.createElement('div');
    quickOrderModal.id = 'quickOrderModal';
    quickOrderModal.className = 'fixed inset-0 bg-black bg-opacity-50 z-50 flex items-center justify-center';

    quickOrderModal.innerHTML = `
                <div class="bg-white rounded-2xl p-8 max-w-md w-full mx-4 relative">
                    <button onclick="closeQuickOrder()" class="absolute top-4 left-4 text-gray-400 hover:text-gray-600">
                        <i class="fas fa-times text-xl"></i>
                    </button>
                    
                    <div class="text-center mb-6">
                        <div class="bg-green-600 text-white p-3 rounded-full w-16 h-16 flex items-center justify-center mx-auto mb-4">
                            <i class="fas fa-phone text-2xl"></i>
                        </div>
                        <h2 class="text-2xl font-bold text-gray-800 mb-2">سفارش تلفنی</h2>
                        <p class="text-gray-600">با کارشناسان ما تماس بگیرید</p>
                    </div>
                    
                    <div class="space-y-4">
                        <div class="bg-blue-50 border border-blue-200 rounded-xl p-4">
                            <div class="flex items-center justify-between">
                                <div>
                                    <div class="font-bold text-blue-800">خط ویژه سفارش</div>
                                    <div class="text-blue-600">061-32921023</div>
                                </div>
                                <a href="tel:06132921023" class="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors">
                                    <i class="fas fa-phone ml-2"></i>تماس
                                </a>
                            </div>
                        </div>
                        
                        <div class="bg-green-50 border border-green-200 rounded-xl p-4">
                            <div class="flex items-center justify-between">
                                <div>
                                    <div class="font-bold text-green-800">پشتیبانی 24/7</div>
                                    <div class="text-green-600">061-32921023</div>
                                </div>
                                <a href="tel:06132921023" class="bg-green-600 text-white px-4 py-2 rounded-lg hover:bg-green-700 transition-colors">
                                    <i class="fas fa-headset ml-2"></i>تماس
                                </a>
                            </div>
                        </div>
                        
                        <div class="bg-purple-50 border border-purple-200 rounded-xl p-4">
                            <div class="text-center">
                                <div class="font-bold text-purple-800 mb-2">ساعات کاری</div>
                                <div class="text-purple-600 text-sm">
                                    شنبه تا چهار‌شنبه: 8:00 - 16:00<br>
                                    پنج شنبه: 8:00 - 14:00
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="mt-6 text-center">
                        <p class="text-sm text-gray-500 mb-4">یا می‌توانید فرم آنلاین را تکمیل کنید</p>
                        <a asp-controller="Home" asp-action="KPOrder"
                           class="bg-gradient-to-r from-blue-600 to-green-600 text-white px-6 py-3 rounded-xl font-medium hover:shadow-lg transition-all inline-block">
                            <i class="fas fa-edit ml-2"></i>
                            تکمیل فرم آنلاین
                        </a>
                    </div>
                </div>
            `;

    document.body.appendChild(quickOrderModal);

    // Close modal when clicking on backdrop
    quickOrderModal.addEventListener('click', function (e) {
        if (e.target === this) {
            closeQuickOrder();
        }
    });
}

function closeQuickOrder() {
    const modal = document.getElementById('quickOrderModal');
    if (modal) {
        document.body.removeChild(modal);
    }
}

// Add navigation link to shipping order form
function addShippingOrderNavigation() {
    //// Add to desktop navigation
    //const desktopNav = document.querySelector('nav.hidden.md\\:flex');
    //if (desktopNav) {
    //    const shippingOrderLink = document.createElement('a');
    //    shippingOrderLink.href = '#shipping-order';
    //    shippingOrderLink.className = 'hover:text-green-300 transition-colors';
    //    shippingOrderLink.textContent = 'سفارش حمل بار';
    //    desktopNav.appendChild(shippingOrderLink);
    //}

    //// Add to mobile navigation
    //const mobileNav = document.querySelector('#mobile-menu nav');
    //if (mobileNav) {
    //    const mobileShippingOrderLink = document.createElement('a');
    //    mobileShippingOrderLink.href = '#shipping-order';
    //    mobileShippingOrderLink.className = 'text-white hover:text-green-300 transition-colors py-2';
    //    mobileShippingOrderLink.textContent = 'سفارش حمل بار';
    //    mobileNav.appendChild(mobileShippingOrderLink);
    //}
}

// Initialize shipping order navigation
document.addEventListener('DOMContentLoaded', function () {
    addShippingOrderNavigation();
});

// Form field validation on blur
document.addEventListener('DOMContentLoaded', function () {
    const requiredFields = document.querySelectorAll('#shippingOrderForm [required]');

    requiredFields.forEach(field => {
        field.addEventListener('blur', function () {
            if (!this.value.trim()) {
                this.classList.add('border-red-500', 'bg-red-50');
                this.classList.remove('border-gray-300');
            } else {
                this.classList.remove('border-red-500', 'bg-red-50');
                this.classList.add('border-gray-300');
            }
        });

        field.addEventListener('input', function () {
            if (this.value.trim()) {
                this.classList.remove('border-red-500', 'bg-red-50');
                this.classList.add('border-gray-300');
            }
        });
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const carousel = document.getElementById('services-carousel');
    const prevBtn = document.getElementById('prev-btn');
    const nextBtn = document.getElementById('next-btn');
    const cards = carousel.children;
    const cardWidth = cards[0].offsetWidth + 16; // width + gap

    let currentIndex = 0;
    let autoSlideInterval;

    function updateCarousel() {
        carousel.style.transform = `translateX(-${currentIndex * cardWidth}px)`;
    }

    function nextSlide() {
        if (currentIndex < cards.length - 1) {
            currentIndex++;
        } else {
            currentIndex = 0;
        }
        updateCarousel();
    }

    function prevSlide() {
        if (currentIndex > 0) {
            currentIndex--;
        } else {
            currentIndex = cards.length - 1;
        }
        updateCarousel();
    }

    nextBtn.addEventListener('click', () => {
        nextSlide();
        resetAutoSlide();
    });

    prevBtn.addEventListener('click', () => {
        prevSlide();
        resetAutoSlide();
    });

    function startAutoSlide() {
        autoSlideInterval = setInterval(nextSlide, 3000);
    }

    function resetAutoSlide() {
        clearInterval(autoSlideInterval);
        startAutoSlide();
    }

    // Start auto sliding
    startAutoSlide();

    // Pause auto-slide on hover
    carousel.addEventListener('mouseenter', () => {
        clearInterval(autoSlideInterval);
    });

    carousel.addEventListener('mouseleave', () => {
        startAutoSlide();
    });
});

// Placeholder functions for buttons
function scrollToSection(id) {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' });
}

function openInternationalServices() {
    alert('در حال باز کردن صفحه خدمات بین‌المللی...');
}

function openSpecialServices() {
    alert('در حال باز کردن صفحه خدمات ویژه...');
}

function openCorporateServices() {
    alert('در حال باز کردن صفحه خدمات سازمانی...');
}
// Services Scroll Function
function scrollServices(direction) {
    const container = document.getElementById('servicesContainer');
    const scrollAmount = 320; // Width of one card plus gap

    if (direction === 'left') {
        container.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
    } else {
        container.scrollBy({ left: scrollAmount, behavior: 'smooth' });
    }
}

// FAQ Toggle Functionality
document.querySelectorAll('.bg-gray-50').forEach(button => {
    button.addEventListener('click', function () {
        const icon = this.querySelector('i');
        const content = this.nextElementSibling;

        if (content.classList.contains('hidden')) {
            content.classList.remove('hidden');
            icon.classList.remove('fa-chevron-down');
            icon.classList.add('fa-chevron-up');
        } else {
            content.classList.add('hidden');
            icon.classList.remove('fa-chevron-up');
            icon.classList.add('fa-chevron-down');
        }
    });
});