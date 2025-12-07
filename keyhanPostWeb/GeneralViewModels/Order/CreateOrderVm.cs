using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class CreateOrderVm
    {
        public CreateOrderStep0Vm Step0Vm { get; set; }
        public CreateOrderStep1Vm Step1Vm { get; set; }
        public CreateOrderStep2Vm Step2Vm { get; set; }
        public CreateOrderStep3Vm Step3Vm { get; set; }
        public CreateOrderStep4Vm Step4Vm { get; set; }


        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> OriginCities { get; set; }
        public int? OrderId { get; set; }
        public short Step { get; set; }

    }
    public class CreateOrderStep0Vm
    {
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "وارد کردن شماره موبایل الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل وارد شده معتبر نیست.")]
        public string Mobile { get; set; }

    }
    public class CreateOrderStep1Vm
    {

        public int OrderId { get; set; }

        [DisplayName("نوع بسته")]
        [Required(ErrorMessage = "انتخاب نوع بسته الزامی است.")]
        public short PackageTypeId { get; set; }

    }
    public class CreateOrderStep2Vm
    {

        public int OrderId { get; set; }

        [DisplayName("شهر مبدا")]
        [Range(1, int.MaxValue, ErrorMessage = "انتخاب شهر مبدا الزامی است.")]
        public int OriginCityId { get; set; }

        [DisplayName("شهر مقصد")]
        [Range(1, int.MaxValue, ErrorMessage = "انتخاب شهر مقصد الزامی است.")]
        public int DestinationCityId { get; set; }

        [DisplayName("طول (سانتی‌متر)")]
        public double? Length { get; set; }

        [DisplayName("عرض (سانتی‌متر)")]
        public double? Width { get; set; }

        [DisplayName("ارتفاع (سانتی‌متر)")]
        public double? Height { get; set; }

        [DisplayName("وزن واقعی (کیلوگرم)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "وارد کردن وزن واقعی الزامی است.")]
        public double ActualWeight { get; set; }

        [DisplayName("نوع حمل")]
        [Required(ErrorMessage = "انتخاب نوع حمل الزامی است.")]
        //1وانت
        //2موتور
        public short DeliveryVehicleType { get; set; }


    }
    public class CreateOrderStep3Vm
    {

        public int OrderId { get; set; }


        [DisplayName("نوع شخصیت ")]
        [Required(ErrorMessage = "انتخاب نوع شخصیت الزامی است.")]
        public int SenderEntityTypeId { get; set; }


        [DisplayName("نام ")]
        [Required(ErrorMessage = "وارد کردن نام الزامی است.")]
        public string SenderFirstName { get; set; }


        [DisplayName("نام خانوادگی ")]
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است.")]
        public string SenderLastName { get; set; }


        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "وارد کردن کد ملی الزامی است.")]
        [RegularExpression(@"^(?!0{10})(?!1{10})(?!2{10})(?!3{10})(?!4{10})(?!5{10})(?!6{10})(?!7{10})(?!8{10})(?!9{10})\d{10}$",
        ErrorMessage = "کد ملی معتبر نیست.")]
        public string SenderNationalId { get; set; }



        [DisplayName("شماره همراه ")]
        [Required(ErrorMessage = "وارد کردن شماره همراه الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه معتبر نیست. باید با 09 شروع شود و 11 رقم باشد.")]
        public string SenderMobile { get; set; }

        [DisplayName("شماره ثابت ")]
        [RegularExpression(@"^0\d{2,3}\d{7,8}$", ErrorMessage = "شماره ثابت معتبر نیست. باید شامل کد شهر و شماره باشد.")]
        public string? SenderPhone { get; set; }


        [DisplayName("آدرس ")]
        [Required(ErrorMessage = "وارد کردن آدرس الزامی است.")]
        public string SenderAddress { get; set; }

        //اگر حقوقی بود
        [DisplayName("نام شرکت (حقوقی)")]
        public string? SenderCompanyName { get; set; }


        [DisplayName("شناسه ملی شرکت")]
        [RegularExpression(@"^(\d{11})?$", ErrorMessage = "شناسه ملی باید 11 رقم باشد.")]
        public string? SenderCompanyNationalId { get; set; }
    }

    public class CreateOrderStep4Vm
    {

        public int OrderId { get; set; }

        [DisplayName("نوع شخصیت ")]
        public int ReceiverEntityTypeId { get; set; }

        [DisplayName("نام ")]
        [Required(ErrorMessage = "وارد کردن نام الزامی است.")]
        public string ReceiverFirstName { get; set; }

        [DisplayName("نام خانوادگی ")]
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است.")]
        public string ReceiverLastName { get; set; }


        [DisplayName("کد ملی")]
        [Required(ErrorMessage = "وارد کردن کد ملی الزامی است.")]
        [RegularExpression(@"^(?!0{10})(?!1{10})(?!2{10})(?!3{10})(?!4{10})(?!5{10})(?!6{10})(?!7{10})(?!8{10})(?!9{10})\d{10}$",
        ErrorMessage = "کد ملی معتبر نیست.")]
        public string ReceiverNationalId { get; set; }

        [DisplayName("شماره همراه ")]
        [Required(ErrorMessage = "وارد کردن شماره همراه الزامی است.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره همراه معتبر نیست. باید با 09 شروع شود و 11 رقم باشد.")]
        public string ReceiverMobile { get; set; }

        [DisplayName("شماره ثابت ")]
        [RegularExpression(@"^0\d{2,3}\d{7,8}$", ErrorMessage = "شماره ثابت معتبر نیست. باید شامل کد شهر و شماره باشد.")]
        public string? ReceiverPhone { get; set; }

        [DisplayName("آدرس ")]
        [Required(ErrorMessage = "وارد کردن آدرس  الزامی است.")]
        public string ReceiverAddress { get; set; }


        //اگر حقوقی بود
        [DisplayName("نام شرکت  (حقوقی)")]
        public string? ReceiverCompanyName { get; set; }


        [DisplayName("شناسه ملی شرکت")]
        [RegularExpression(@"^(\d{11})?$", ErrorMessage = "شناسه ملی باید 11 رقم باشد.")]
        public string? ReceiverCompanyNationalId { get; set; }

    }


}
