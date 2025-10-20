"use strict";

$(document).ready(function () {
    // main modal for large and small devices
    const mainModal = new bootstrap.Modal($("#mainModal")[0], {});

    // Cache all DOM elements once
    const $registerLinkMobile = $("#registerLinkMobile");
    const $loginLinkMobile = $("#loginLinkMobile");
    const $loginTab = $("#pills-login");
    const $registerTab = $("#pills-register");
    const $loginTabButton = $("#tab-login");
    const $registerTabButton = $("#tab-register");

    const $loginLink = $("#loginLink");
    const $registerLink = $("#registerLink");
    const $formImage = $("#formImage");
    const $formContent = $("#formContent");
    const $loginForm = $(".loginForm");
    const $registerForm = $(".registerForm");

    /* =====================================================
      Tab Login/Register Modal For Small Devices
    ======================================================== */

    // mobile login/register modal tab
    function switchTab(targetTab, currentTab, targetButton, currentButton) {
        // Update the active state of the tab buttons
        currentButton.removeClass("active");
        targetButton.addClass("active");

        // Hide the current tab content with fade effect
        currentTab.removeClass("show active").addClass("fade");

        setTimeout(function () {
            currentTab.removeClass("fade show active");
        }, 200);

        // Show the target tab content with fade effect
        targetTab.addClass("show active");
        setTimeout(function () {
            targetTab.removeClass("fade");
        }, 200);
    }

    // tab activating process calling
    $registerLinkMobile.on("click", function (event) {
        event.preventDefault();
        switchTab($registerTab, $loginTab, $registerTabButton, $loginTabButton);
    });

    $loginLinkMobile.on("click", function (event) {
        event.preventDefault();
        switchTab($loginTab, $registerTab, $loginTabButton, $registerTabButton);
    });

    /* =====================================================
      Sliding Login/Register Modal Start With Medium Devices
    ======================================================== */

    // register slide - نسخه اصلاح شده برای RTL
    $registerLink.on("click", function (event) {
        event.preventDefault();

        // برای RTL جهت انیمیشن‌ها را معکوس می‌کنیم
        $formImage.removeClass("slide-in-rtl").addClass("slide-in-reverse-rtl");
        $formContent.removeClass("slide-in-rtl").addClass("slide-out-rtl");

        setTimeout(() => {
            $loginForm.removeClass("form-show");
            $registerForm.addClass("form-show");
        }, 300);

        $formImage.css("background-image", 'url("https://i.ibb.co/2sL6wtP/movie-poster-register.jpg")');
    });

    // login slide - نسخه اصلاح شده برای RTL
    $loginLink.on("click", function (event) {
        event.preventDefault();

        $formImage.removeClass("slide-in-reverse-rtl").addClass("slide-in-rtl");
        $formContent.removeClass("slide-out-rtl").addClass("slide-in-rtl");

        setTimeout(() => {
            $registerForm.removeClass("form-show");
            $loginForm.addClass("form-show");
        }, 300);

        $formImage.css("background-image", 'url("../img/ui/logo.png")');
        //$formImage.css("background-image", 'url("https://i.ibb.co/JQNt37h/avenger-movie-login.jpg")');
    });
});