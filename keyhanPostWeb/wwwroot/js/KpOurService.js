// Tab switching functionality
function showTab(tabName) {
    // Update tab buttons
    document.querySelectorAll('.tab-button').forEach(btn => {
        btn.classList.remove('active');
    });
    document.getElementById(tabName + 'Tab').classList.add('active');

    // Scroll to section
    scrollToSection(tabName);
}

// Smooth scroll function
function scrollToSection(sectionId) {
    const element = document.getElementById(sectionId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
}

// Service contact function
function contactForService(serviceName) {
    alert('درخواست مشاوره برای ' + serviceName + ':\n\nبرای دریافت اطلاعات کامل و مشاوره رایگان با شماره 021-88776655 تماس بگیرید.\n\nیا از طریق فرم تماس در پایین صفحه درخواست خود را ارسال کنید.');
}

// Mobile menu functionality
document.getElementById('mobile-menu-btn').addEventListener('click', function () {
    // Mobile menu functionality would be implemented here
    alert('منوی موبایل در حال توسعه است.');
});

// Form submission
document.querySelector('form').addEventListener('submit', function (e) {
    e.preventDefault();
    alert('درخواست شما با موفقیت ارسال شد. کارشناسان ما در اسرع وقت با شما تماس خواهند گرفت.');
});

// Intersection Observer for animations
const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('fade-in');
        }
    });
}, observerOptions);

// Observe service cards
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.service-card').forEach(card => {
        observer.observe(card);
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