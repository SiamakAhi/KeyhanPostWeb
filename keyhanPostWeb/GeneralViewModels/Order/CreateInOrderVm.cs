using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class CreateInOrderVm
    {
        public CreateInOrderStep0Vm  InStep0Vm { get; set; }
        public CreateInOrderStep1Vm InStep1Vm { get; set; }
        public CreateInOrderStep2Vm InStep2Vm { get; set; }
        public CreateInOrderStep3Vm InStep3Vm { get; set; }

        public int? OrderId { get; set; }
        public short Step { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> contries { get; set; }
    }
        public class CreateInOrderStep0Vm
        {
            [DisplayName("شماره موبایل")]
            [Required(ErrorMessage = "وارد کردن شماره موبایل الزامی است.")]
            [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل وارد شده معتبر نیست.")]
            public string Mobile { get; set; }

        }
        public class CreateInOrderStep1Vm
        {

            public int OrderId { get; set; }

            //عادی=1
            //الکترونیکی=2
            //پاکت=3
            //فاسد شدنی=4
            //5=کالبد متوفی
            //6=حیوان خانگی
            // --- نوع بسته ---
            [DisplayName("نوع بسته")]
            [Required(ErrorMessage = "انتخاب نوع بسته الزامی است.")]
            public short PackageTypeId { get; set; }

        }
        public class CreateInOrderStep2Vm
        {

            public int OrderId { get; set; }

        [DisplayName("کشور مبدا ")]
        [Required(ErrorMessage = "لطفاً کشور مبدا را انتخاب کنید.")]
            public string? OriginCountryName { get; set; }

        [DisplayName("کشور مقصد ")]
        [Required(ErrorMessage = "لطفاً کشور مقصد را انتخاب کنید.")]
            public string? DestinationCountryName { get; set; }
            // --- ابعاد و وزن ---
            [Range(1, 500, ErrorMessage = "طول باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
            [Display(Name = "طول (cm)")]
            public double Length { get; set; }

            [Range(1, 500, ErrorMessage = "عرض باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
            [Display(Name = "عرض (cm)")]
            public double Width { get; set; }

            [Range(1, 500, ErrorMessage = "ارتفاع باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
            [Display(Name = "ارتفاع (cm)")]
            public double Height { get; set; }

            [DisplayName("وزن واقعی (کیلوگرم)")]
            [Range(0.1, 200, ErrorMessage = "وزن باید بین ۰.۱ تا ۲۰۰ کیلوگرم باشد.")]
            [Required(ErrorMessage = "لطفاً وزن واقعی را وارد کنید.")]
            public double ActualWeight { get; set; }


        }
        public class CreateInOrderStep3Vm
        {

            public int OrderId { get; set; }

            [DisplayName("نام ")]
            [Required(ErrorMessage = "وارد کردن نام الزامی است.")]
            public string RequesterFirstName { get; set; }


            [DisplayName("نام خانوادگی ")]
            [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است.")]
            public string RequesterLastName { get; set; }

            [DisplayName("شماره همراه ")]
            [Required(ErrorMessage = "وارد کردن شماره همراه الزامی است.")]
            [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه معتبر نیست. باید با 09 شروع شود و 11 رقم باشد.")]
            public string RequesterMobile { get; set; }

            [DisplayName("شماره ثابت ")]
            [RegularExpression(@"^0\d{2,3}\d{7,8}$", ErrorMessage = "شماره ثابت معتبر نیست. باید شامل کد شهر و شماره باشد.")]
            public string RequesterPhone { get; set; }

            [DisplayName("شهر درخواست‌کننده")]
            [Required(ErrorMessage = "لطفاً شهر را انتخاب کنید.")]
            public int RequesterCityId { get; set; }

        }



    }
