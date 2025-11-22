using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class Order
    {
        [Key]
        [DisplayName("شناسه سفارش")]
        public int Id { get; set; }

       //عادی=1
       //الکترونیکی=2
       //پاکت=3
       //فاسد شدنی=4
       //5=کالبد متوفی
       //6=حیوان خانگی
        // --- نوع بسته ---
        [DisplayName("نوع بسته")]
        [Required]
        public short PackageTypeId { get; set; }

        // --- شهر مبدا ---
        [DisplayName("شهر مبدا")]
        
        public int? OriginCityId { get; set; }

       

        // --- شهر مقصد ---
        [DisplayName("شهر مقصد")]
        
        public int? DestinationCityId { get; set; }

        // 1 داخلی
        //2 بین المللی
        [DisplayName("نوع سفارش")]
        [Required]
        public int OrderType { get; set; }

        [Required(ErrorMessage = "لطفاً کشور مبدا را انتخاب کنید.")]
        public string? OriginCountryName { get; set; }

        [Required(ErrorMessage = "لطفاً کشور مقصد را انتخاب کنید.")]
        public string? DestinationCountryName { get; set; }

        // --- ابعاد و وزن ---
        [DisplayName("طول (سانتی‌متر)")]
        public double Length { get; set; }

        [DisplayName("عرض (سانتی‌متر)")]
        public double Width { get; set; }

        [DisplayName("ارتفاع (سانتی‌متر)")]
        public double Height { get; set; }

        [DisplayName("وزن واقعی (کیلوگرم)")]
        public double ActualWeight { get; set; }

        // --- اطلاعات فرستنده ---
        [DisplayName("نام فرستنده")]
        [Required, MaxLength(100)]
        public string SenderName { get; set; }

      

        [DisplayName("شماره تماس فرستنده")]
        [Required, MaxLength(20)]
        public string SenderPhone { get; set; }

        [DisplayName("کد ملی فرستنده")]
        [StringLength(10)]
        public string? SenderNationalId { get; set; }

        [DisplayName("آدرس فرستنده")]
        [ MaxLength(500)]
        public string? SenderAddress { get; set; }

        // --- اطلاعات گیرنده ---
        [DisplayName("نام و نام خانوادگی گیرنده")]
        [Required, MaxLength(100)]
        public string ReceiverName { get; set; }

        [DisplayName("شماره تماس گیرنده")]
        [Required, MaxLength(20)]
        public string ReceiverPhone { get; set; }

        [DisplayName("کد ملی گیرنده")]
        [StringLength(10)]
        public string? ReceiverNationalId { get; set; }

        [DisplayName("آدرس گیرنده")]
        [MaxLength(500)]
        public string? ReceiverAddress { get; set; }

        // --- وضعیت سفارش ---
        [DisplayName("وضعیت سفارش")]
        [Required]
        public int OrderStatusId { get; set; }

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; }

        // --- سایر اطلاعات ---
        [DisplayName("کد رهگیری")]
        public string TrackingCode { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
