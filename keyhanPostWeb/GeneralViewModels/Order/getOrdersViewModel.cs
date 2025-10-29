using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class getOrdersViewModel
    {

      
        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        [DisplayName("نوع بسته")]
        [Required]
        public string PackageTypeName { get; set; }

        // --- شهر مبدا ---
        [DisplayName("شهر مبدا")]
        [Required]
        public string OriginCityname { get; set; }



        // --- شهر مقصد ---
        [DisplayName("شهر مقصد")]
        [Required]
        public string DestinationCityname { get; set; }



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
        [DisplayName("نام و نام خانوادگی فرستنده")]
        [Required, MaxLength(100)]
        public string SenderName { get; set; }

        [DisplayName("شماره تماس فرستنده")]
        [Required, MaxLength(20)]
        public string SenderPhone { get; set; }

        [DisplayName("کد ملی فرستنده")]
        [StringLength(10)]
        public string SenderNationalId { get; set; }

        [DisplayName("آدرس فرستنده")]
        [Required, MaxLength(500)]
        public string SenderAddress { get; set; }

        // --- اطلاعات گیرنده ---
        [DisplayName("نام و نام خانوادگی گیرنده")]
        [Required, MaxLength(100)]
        public string ReceiverName { get; set; }

        [DisplayName("شماره تماس گیرنده")]
        [Required, MaxLength(20)]
        public string ReceiverPhone { get; set; }

        [DisplayName("کد ملی گیرنده")]
        [StringLength(10)]
        public string ReceiverNationalId { get; set; }

        [DisplayName("آدرس گیرنده")]
        [Required, MaxLength(500)]
        public string ReceiverAddress { get; set; }

        // --- وضعیت سفارش ---
        [DisplayName("وضعیت سفارش")]
        [Required]
        public int OrderStatusId { get; set; }


        // --- سایر اطلاعات ---
        [DisplayName("کد رهگیری")]
        public string TrackingCode { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public string CreatedAt { get; set; } 
    }
}
