
$(document).ready(function () {

    $(document).on('click', '.path-city', function () {
        var target = $(this).data('target');
        

        $('.branch-list > li').each(function(){
            $(this).removeClass('selected');
        });

        $('li[name='+target+ ']') .each(function(){
             $(this).addClass('selected');
        })
    });


    //$('.branch-list > li').hover(function () {
      
    //    var target = $(this).attr('name');
    //    $('.path-city[data-target=' + target + ']').css("fill", "yellow");
       
    //}, function () {
    //    var target = $(this).attr('name');
    //    $('.path-city[data-target=' + target + ']').css("fill", "blue");
    //}
    //)
})
function ShowLoading() {
    $("#loading").show();
}

function HideLoading() {
    $("#loading").hide();
}

// --- Step 1 ---
$(document).on('submit', '#frmStep1', function (e) {
    e.preventDefault();
    ShowLoading();

    let frm = $(this);
    let submitBtn = frm.find('.accAjaxSubmit');
    submitBtn.prop('disabled', true).text('در حال ارسال...');

    $.ajax({
        url: frm.attr('action'),
        type: 'POST',
        data: new FormData(this),
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (result) {
            if (result.Success) {
                Swal.fire({
                    title: 'موفق',
                    html: `<p>درخواست با موفقیت ثبت شد</p>
                               <button id="btnContinueStep1" class="btn btn-primary mt-3">ادامه</button>`,
                    icon: 'success',
                    showConfirmButton: false,
                    didOpen: () => {
                        const btn = Swal.getPopup().querySelector('#btnContinueStep1');
                        btn.addEventListener('click', () => {
                            Swal.close();
                            LoadStep2();
                        });
                    }
                });
            } else {
                Swal.fire('خطا', result.Message, 'error');
            }
        },
        error: function () {
            Swal.fire('خطا', 'خطایی در ارسال رخ داد', 'error');
        },
        complete: function () {
            submitBtn.prop('disabled', false).text('مرحله بعد');
            HideLoading();
        }
    });
});

function LoadStep2() {
    ShowLoading();
    $.get("/Job/CreateJobRequest_step2", function (data) {
        $("#requestContainer").html(data);
    }).always(HideLoading);
}

// --- Step 2 ---
$(document).on('submit', '#frmStep2', function (e) {
    e.preventDefault();
    ShowLoading();

    let frm = $(this);
    let submitBtn = frm.find('.accAjaxSubmit');
    submitBtn.prop('disabled', true).text('در حال ارسال...');

    $.ajax({
        url: frm.attr('action'),
        type: 'POST',
        data: new FormData(this),
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (result) {
            if (result.Success) {
                Swal.fire({
                    title: 'موفق',
                    html: `<p>درخواست با موفقیت ثبت شد</p>
                               <button id="btnContinueStep2" class="btn btn-primary mt-3">ادامه</button>`,
                    icon: 'success',
                    showConfirmButton: false,
                    didOpen: () => {
                        const btn = Swal.getPopup().querySelector('#btnContinueStep2');
                        btn.addEventListener('click', () => {
                            Swal.close();
                            LoadStep3();
                        });
                    }
                });
            } else {
                Swal.fire('خطا', result.Message, 'error');
            }
        },
        error: function () {
            Swal.fire('خطا', 'خطایی در ارسال رخ داد', 'error');
        },
        complete: function () {
            submitBtn.prop('disabled', false).text('مرحله بعد');
            HideLoading();
        }
    });
});

function LoadStep3() {
    ShowLoading();
    $.get("/Job/CreateJobRequest_step3", function (data) {
        $("#requestContainer").html(data);
    }).always(HideLoading);
}

// --- Step 3 (ارسال نهایی) ---
$(document).on('submit', '#frmStep3', function (e) {
    e.preventDefault();
    ShowLoading();

    let frm = $(this);
    let submitBtn = frm.find('.accAjaxSubmit');
    submitBtn.prop('disabled', true).text('در حال ارسال...');

    $.ajax({
        url: frm.attr('action'),
        type: 'POST',
        data: new FormData(this),
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (result) {
            if (result.Success) {
                Swal.fire({
                    title: 'موفق',
                    html: `<p>${result.Message || 'اطلاعات با موفقیت ثبت شد'}</p>
                               <button id="btnContinueStep3" class="btn btn-primary mt-3">ادامه</button>`,
                    icon: 'success',
                    showConfirmButton: false,
                    didOpen: () => {
                        const btn = Swal.getPopup().querySelector('#btnContinueStep3');
                        btn.addEventListener('click', () => {
                            Swal.close();
                            location.reload(); // یا هر کار دلخواه بعد از پایان
                        });
                    }
                });
            } else {
                Swal.fire('خطا', result.Message, 'error');
            }
        },
        error: function () {
            Swal.fire('خطا', 'خطایی در ارسال رخ داد', 'error');
        },
        complete: function () {
            submitBtn.prop('disabled', false).text('ارسال');
            HideLoading();
        }
    });
});