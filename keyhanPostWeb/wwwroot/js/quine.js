let generalModal = $(document).find('#model-general-larg');
var loder = document.getElementById("loader");

// باز کردن مودال با محتوای AJAX
$(document).on('click', '.callform[data-url]', function () {

    let actionUrl = $(this).data('url');

    $.get(actionUrl).done(function (data) {

        generalModal.html(data);
        generalModal.modal('show');

        // --- شروع انیمیشن با GSAP فقط بعد از اضافه شدن محتوا ---
        const animatedBox = generalModal.find(".animated-box")[0]; // کلاس المان موردنظر برای انیمیشن
        if (animatedBox) {
            gsap.from(animatedBox, {
                y: -50,
                opacity: 0,
                duration: 0.5,
                ease: "power1.out"
            });
        } else {
            console.warn("GSAP target not found!");
        }

    }).fail(function () {
        console.error("Failed to load modal content from: ", actionUrl);
    });
});

// ارسال فرم AJAX و نمایش loader
$(document).on('click', '.submitCustomAction', function () {
    if (loder) loder.style.display = "block";

    let frm = $(this).closest('form');
    let actionUrl = $(this).data('url');
    let dataToSend = new FormData(frm.get(0));

    $.ajax({
        url: actionUrl,
        type: 'post',
        data: dataToSend,
        processData: false,
        contentType: false
    }).done(function (data) {
        let result = JSON.parse(data);

        if (result['Success']) {
            if (result['ShowMessage']) {
                Swal.fire({
                    title: 'کاربر گرامی!',
                    html: result['Message'],
                    icon: 'success',
                    customClass: { confirmButton: 'btn btn-success' },
                    confirmButtonText: 'متوجه شدم',
                    buttonsStyling: false
                });
            }

            setTimeout(() => {
                if (parseInt(result['updateType']) === 1 && result['returnUrl']) {
                    window.location.href = result['returnUrl'];
                } else if (result['returnUrl']) {
                    const target = $(document).find(result['updateTargetId']);
                    if (target.length) {
                        $.get(result['returnUrl']).done(function (newData) {
                            target.html(newData);
                            $('#accmodal').modal('hide');
                            $(document).find('.select2').select2();
                        });
                    }
                }
            }, 300);

        } else {
            Swal.fire({
                title: 'کاربر گرامی!',
                html: result['Message'],
                icon: 'warning',
                customClass: { confirmButton: 'btn btn-primary' },
                confirmButtonText: 'باشه',
                buttonsStyling: false
            });
        }
    }).always(function () {
        if (loder) loder.style.display = "none";
    });
});

$(document).on('click', '.accAjaxSubmit', function () {

    let frm = $(this).closest('form');

    let actionUrl = frm.attr('action');
    let dataToSend = new FormData(frm.get(0));

    $.ajax({
        url: actionUrl,
        type: 'post',
        data: dataToSend,
        processData: false,
        contentType: false
    }).done(function (data) {
        let result = JSON.parse(data);

        if (result['Success'] === true) {

            if (result['ShowMessage'] === true) {
                Swal.fire({
                    title: 'کاربـر گـرامی !',
                    html: result['Message'],
                    icon: 'success',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    },
                    confirmButtonText: 'متوجه شدم',
                    buttonsStyling: false
                });
            }

            $(this).delay(200).queue(function () {
                if (parseInt(result['updateType']) === 1) {
                    if (result['returnUrl']) window.location.href = result['returnUrl'];
                }
                else {
                    if (result['returnUrl']) {
                        var getUrl = result['returnUrl'];
                        var target = result['updateTargetId'];

                        $.get(getUrl).done(function (newData) {
                            $(document).find(target).html(newData);
                            var modalTarge = $(document).find('#accmodal');
                            modalTarge.modal('hide');
                            $(document).find('.select2').select2();
                        });
                    }
                }
            })
        }
        else {
            Swal.fire({
                title: 'کاربـر گـرامی !',
                html: result['Message'],
                icon: 'warning',
                customClass: {
                    confirmButton: 'btn btn-primary'
                },
                confirmButtonText: 'باشه',
                buttonsStyling: false
            });
        }


    }).always(function () {
        /*  loder.style.display = "none";*/
    });
});