using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class GetInOrderDetailVm
    {
       

        // ---------------------- OTP ---------------------- //
        [DisplayName("شماره همراه ثبت‌کننده سفارش")]
        public string? MobileForOtp { get; set; }

       

        //----------------------step1----------------------//
        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        //5=کالبد متوفی
        //6=حیوان خانگی
        [DisplayName("نوع بسته")]

        public string? PackageTypeName { get; set; }


        //----------------------step2----------------------//
        [DisplayName("نام کشور مبدا")]
        public string? OriginCountryName { get; set; }

        [DisplayName("نام کشور مقصد")]
        public string? DestinationCountryName { get; set; }

        // --- ابعاد و وزن ---
        [DisplayName("طول (سانتی‌متر)")]
        public double? Length { get; set; }

        [DisplayName("عرض (سانتی‌متر)")]
        public double? Width { get; set; }

        [DisplayName("ارتفاع (سانتی‌متر)")]
        public double? Height { get; set; }

        [DisplayName("وزن واقعی (کیلوگرم)")]

        public double? ActualWeight { get; set; }

        // --- اطلاعات درخواست کننده ---
        [DisplayName("نام درخواست‌کننده")]

        public string? RequesterName { get; set; }


        [DisplayName("شماره تماس درخواست‌کننده")]

        public string? RequesterMobile { get; set; }

        [DisplayName("شماره تماس ثابت درخواست‌کننده")]

        public string? RequesterPhone { get; set; }

        [DisplayName("شهر درخواست‌کننده")]
        public string? RequesterCityName { get; set; }

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
