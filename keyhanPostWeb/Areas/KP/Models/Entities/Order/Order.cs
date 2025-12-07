using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order;



    public class Order
    {
    // ---------------------- OTP ---------------------- //
    [DisplayName("شماره همراه ثبت‌کننده سفارش")]
    public string? MobileForOtp { get; set; }

    [DisplayName("کد تایید ارسال شده")]
    public string? OtpCode { get; set; }

    [DisplayName("تاریخ انقضای کد تایید")]
    public DateTime? OtpExpireAt { get; set; }
    [Key]
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

    //----------------------step2----------------------//
    [DisplayName("شهر مبدا")]
    public int? OriginCityId { get; set; }

    [DisplayName("شهر مقصد")]
    public int? DestinationCityId { get; set; }

    // --- وزن و ابعاد ---
    [DisplayName("طول (سانتی‌متر)")]
    public double? Length { get; set; }

    [DisplayName("عرض (سانتی‌متر)")]
    public double? Width { get; set; }

    [DisplayName("ارتفاع (سانتی‌متر)")]
    public double? Height { get; set; }

    [DisplayName("وزن واقعی (کیلوگرم) *")]
    public double? ActualWeight { get; set; }

    [DisplayName("نوع حمل")]
    public short? DeliveryVehicleType { get; set; }

    //----------------------step3----------------------//
    // --- اطلاعات فرستنده ---
    [DisplayName("نوع شخصیت فرستنده")]
    public int? SenderEntityTypeId { get; set; }
    [ForeignKey(nameof(SenderEntityTypeId))]
    public RepEntityType? SenderEntityType { get; set; }


    [DisplayName("نام فرستنده )")]
    public string? SenderFirstName { get; set; }

    [DisplayName("نام خانوادگی فرستنده)")]
    public string? SenderLastName { get; set; }

    [DisplayName("کد ملی فرستنده)")]
    public string? SenderNationalId { get; set; }

    [DisplayName("شماره همراه فرستنده *")]
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
    public int? ReceiverEntityTypeId { get; set; }

    [ForeignKey(nameof(ReceiverEntityTypeId))]
    public RepEntityType? ReceiverEntityType { get; set; }

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
    [Required]
    public int OrderStatusId { get; set; }

    [ForeignKey(nameof(OrderStatusId))]
    public OrderStatus OrderStatus { get; set; }

    // --- سایر اطلاعات ---
    [DisplayName("کد رهگیری")]
    public string? TrackingCode { get; set; }

    [DisplayName("تاریخ ثبت سفارش")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public short CurrentStep {  get; set; }   

    }


