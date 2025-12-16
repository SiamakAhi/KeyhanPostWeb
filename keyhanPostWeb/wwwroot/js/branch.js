
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
    let submitBtn = frm.find('button[type="submit"]');
    let msgDiv = $('#formMessage');

    msgDiv.html(""); // پاک کردن پیام قبلی
    submitBtn.prop('disabled', true).text('در حال ارسال...');

    $.ajax({
        url: frm.attr('action'),
        type: 'POST',
        data: new FormData(this),
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (result) {
         let jresult =  JSON.parse(result);
          /*  alert(jresult['Message']);*/

            if (jresult.Success===true) {
                msgDiv.html(`
                    <div class="p-4 bg-green-100 text-green-700 rounded-lg">
                        درخواست با موفقیت ثبت شد.  
                        <button id="btnContinueStep1" class="bg-blue-600 text-white px-4 py-2 rounded-lg ml-3">
                            ادامه
                        </button>
                    </div>
                `);

                $('#btnContinueStep1').on('click', function () {
                    LoadStep2();
                });

            } else {
               
                msgDiv.html(`
                    <div class="p-4 bg-red-100 text-red-600 rounded-lg">
                       ${jresult['Message']}
                    </div>
                `);
            }
        },
        error: function () {
            msgDiv.html(`
                <div class="p-4 bg-red-100 text-red-600 rounded-lg">
                    خطایی در ارسال رخ داد
                </div>
            `);
        },
        complete: function () {
            submitBtn.prop('disabled', false).text('مرحله بعد');
            HideLoading();
        }
    });
  });



function LoadStep2() {
    ShowLoading();
    $.get("/Job/CreateJobRequest", function (data) {
        $(document).find("#requestContainer").html(data);
    }).always(HideLoading);
}

$(document).on('submit', '#frmStep2', function (e) {
    e.preventDefault();
    ShowLoading();

    let frm = $(this);
    let submitBtn = frm.find('button[type="submit"]');
    let msgDiv = $('#formMessage');

    msgDiv.html(""); // پاک کردن پیام قبلی
    submitBtn.prop('disabled', true).text('در حال ارسال...');

    $.ajax({
        url: frm.attr('action'),
        type: 'POST',
        data: new FormData(this),
        contentType: false,
        processData: false,
        dataType: 'json',
        success: function (result) {
            let jresult = JSON.parse(result);
            if (jresult.Success === true) {
                msgDiv.html(`
                    <div class="p-4 bg-green-100 text-green-700 rounded-lg">
                        درخواست با موفقیت ثبت شد.  
                        <button id="btnContinueStep2" class="bg-blue-600 text-white px-4 py-2 rounded-lg ml-3">
                            ادامه
                        </button>
                    </div>
                `);

                $('#btnContinueStep2').on('click', function () {
                    LoadStep3();
                });

            } else {

                msgDiv.html(`
                    <div class="p-4 bg-red-100 text-red-600 rounded-lg">
                       ${jresult['Message']}
                    </div>
                `);
            }
        },
        error: function () {
            msgDiv.html(`
                <div class="p-4 bg-red-100 text-red-600 rounded-lg">
                    خطایی در ارسال رخ داد
                </div>
            `);
        },
        complete: function () {
            submitBtn.prop('disabled', false).text('مرحله بعد');
            HideLoading();
        }
    });
});
function LoadStep3() {
    ShowLoading();
    $.get("/Job/CreateJobRequest", function (data) {
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
            let jresult = JSON.parse(result);
            if (jresult.Success) {
                Swal.fire({
                    title: 'موفق',
                    html: `<p>${jresult['Message'] || 'اطلاعات با موفقیت ثبت شد'}</p>
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
                Swal.fire('خطا', jresult['Message'], 'error');
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