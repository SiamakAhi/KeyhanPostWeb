// Social sharing functions
function shareOnSocial(platform) {
    const url = encodeURIComponent(window.location.href);
    const title = encodeURIComponent(document.title);

    let shareUrl = '';

    switch (platform) {
        case 'telegram':
            shareUrl = `https://t.me/share/url?url=${url}&text=${title}`;
            break;
        case 'whatsapp':
            shareUrl = `https://wa.me/?text=${title} ${url}`;
            break;
        case 'twitter':
            shareUrl = `https://twitter.com/intent/tweet?url=${url}&text=${title}`;
            break;
        case 'linkedin':
            shareUrl = `https://www.linkedin.com/sharing/share-offsite/?url=${url}`;
            break;
    }

    if (shareUrl) {
        window.open(shareUrl, '_blank', 'width=600,height=400');
    }
}

function copyLink() {
    navigator.clipboard.writeText(window.location.href).then(() => {
        alert('لینک کپی شد!');
    });
}

// Mobile menu functionality
document.getElementById('mobile-menu-btn').addEventListener('click', function () {
    alert('منوی موبایل در حال توسعه است.');
});

// Comment form submission
document.querySelector('form').addEventListener('submit', function (e) {
    e.preventDefault();
    alert('نظر شما با موفقیت ارسال شد و پس از تأیید نمایش داده خواهد شد.');
});

// Newsletter subscription
document.querySelector('.bg-gradient-to-br form').addEventListener('submit', function (e) {
    e.preventDefault();
    alert('با موفقیت در خبرنامه عضو شدید!');
});

// Search functionality
document.querySelector('input[placeholder="جستجو..."]').addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        alert('جستجو برای: ' + this.value);
    }
});

// Smooth scrolling for anchor links
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

// Fade in animation on scroll
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

// Observe elements for animation
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('article, .card-shadow').forEach(element => {
        observer.observe(element);
    });
});