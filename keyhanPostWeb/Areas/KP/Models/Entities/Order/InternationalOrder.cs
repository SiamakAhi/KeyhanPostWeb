using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class InternationalOrder
    {
        [Key]
        [DisplayName("شناسه سفارش")]
        public int Id { get; set; }

        // ---------------------- OTP ---------------------- //
        [DisplayName("شماره همراه ثبت‌کننده سفارش")]
        public string? MobileForOtp { get; set; }

        [DisplayName("کد تایید ارسال شده")]
        public string? OtpCode { get; set; }

        [DisplayName("تاریخ انقضای کد تایید")]
        public DateTime? OtpExpireAt { get; set; }

        //----------------------step1----------------------//
        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        //5=کالبد متوفی
        //6=حیوان خانگی
        [DisplayName("نوع بسته")]
       
        public short? PackageTypeId { get; set; }


        //----------------------step2----------------------//
        
        public string? OriginCountryName { get; set; }

        
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
      
        public string? RequesterFirstName { get; set; }

        [DisplayName("نام خانوادگی درخواست‌کننده")]
       
        public string? RequesterLastName { get; set; }

        [DisplayName("شماره تماس درخواست‌کننده")]
        
        public string? RequesterMobile { get; set; }

        [DisplayName("شماره تماس ثابت درخواست‌کننده")]
        
        public string? RequesterPhone { get; set; }

        [DisplayName("شهر درخواست‌کننده")]
        public int? RequesterCityId { get; set; }

        // --- وضعیت سفارش ---
        [DisplayName("وضعیت سفارش")]
       
        public int? OrderStatusId { get; set; }

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; }

        // --- سایر اطلاعات ---
        [DisplayName("کد رهگیری")]
        public string? TrackingCode { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public short CurrentStep { get; set; }
    }
}
