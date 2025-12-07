using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class GetOrderDetailVm
    {
       
        [DisplayName("شماره همراه ثبت‌کننده سفارش")]
        public string? MobileForOtp { get; set; }

        [DisplayName("شناسه سفارش")]
        public int Id { get; set; }

        //----------------------step1----------------------//
        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        //5=کالبد متوفی
        //6=حیوان خانگی
        [DisplayName("نوع بسته")]
        public short? PackageTypeId { get; set; }

        [DisplayName("نوع بسته")]
        public string PackageTypeName { get; set; }

        //----------------------step2----------------------//
        [Display(Name = "شهر مبدا")]
        public string? OriginCityName { get; set; }

        [Display(Name = "شهر مقصد")]
        public string? DestinationCityName { get; set; }

        // --- وزن و ابعاد ---
        [DisplayName("طول (سانتی‌متر)")]
        public double? Length { get; set; }

        [DisplayName("عرض (سانتی‌متر)")]
        public double? Width { get; set; }

        [DisplayName("ارتفاع (سانتی‌متر)")]
        public double? Height { get; set; }

        [DisplayName("وزن واقعی (کیلوگرم)")]
        public double? ActualWeight { get; set; }

        [DisplayName("نوع حمل")]
        public string? DeliveryVehicleType { get; set; }

        //----------------------step3----------------------//
        // --- اطلاعات فرستنده ---
        [DisplayName("نوع شخصیت فرستنده")]
        public string? SenderEntityType { get; set; }
       
        [DisplayName("نام فرستنده )")]
        public string? SenderFirstName { get; set; }

        [DisplayName("نام خانوادگی فرستنده)")]
        public string? SenderLastName { get; set; }

        [DisplayName("کد ملی فرستنده)")]
        public string? SenderNationalId { get; set; }

        [DisplayName("شماره همراه فرستنده")]
        public string? SenderMobile { get; set; }

        [DisplayName("شماره ثابت فرستنده")]
        public string? SenderPhone { get; set; }

        [DisplayName("آدرس فرستنده")]
        public string? SenderAddress { get; set; }

        // فرستنده حقوقی
        [DisplayName("نام شرکت فرستنده (حقوقی)")]
        public string? SenderCompanyName { get; set; }

        [DisplayName("شناسه ملی شرکت فرستنده")]
        public string? SenderCompanyNationalId { get; set; }
        //----------------------step4----------------------//
        // --- اطلاعات گیرنده ---
        [DisplayName("نوع شخصیت گیرنده")]
        public string? ReceiverEntityType { get; set; }

        [DisplayName("نام گیرنده")]
        public string? ReceiverFirstName { get; set; }

        [DisplayName("نام خانوادگی گیرنده")]
        public string? ReceiverLastName { get; set; }

        [DisplayName("کد ملی گیرنده")]
        public string? ReceiverNationalId { get; set; }

        [DisplayName("شماره همراه گیرنده *")]
        public string? ReceiverMobile { get; set; }

        [DisplayName("شماره ثابت گیرنده")]
        public string? ReceiverPhone { get; set; }

        [DisplayName("آدرس گیرنده")]
        public string? ReceiverAddress { get; set; }

        // گیرنده حقوقی
        [DisplayName("نام شرکت گیرنده)")]
        public string? ReceiverCompanyName { get; set; }

        [DisplayName("شناسه ملی شرکت گیرنده")]
        public string? ReceiverCompanyNationalId { get; set; }

        // --- وضعیت سفارش ---
        [DisplayName("وضعیت سفارش")]
        public string OrderStatus { get; set; }


        // --- سایر اطلاعات ---
        [DisplayName("کد رهگیری")]
        public string? TrackingCode { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public DateTime CreatedAt { get; set; }
   
    }
}
