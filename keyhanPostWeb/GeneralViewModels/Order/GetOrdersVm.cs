using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class GetOrdersVM
    {
        public int OrderId { get; set; }    

        [Display(Name = "کد رهگیری")]
        public string? TrackingCode { get; set; }

        [Display(Name = "شهر مبدا")]
        public string? OriginCityName { get; set; }

        [Display(Name = "شهر مقصد")]
        public string? DestinationCityName { get; set; }

        [Display(Name = "شماره موبایل فرستنده")]
        public string? SenderMobile { get; set; }

        [DisplayName("نام فرستنده")]
        public string? SenderName { get; set; }

        [Display(Name = "شماره موبایل گیرنده")]
        public string? ReceiverMobile { get; set; }

        [DisplayName("نام گیرنده")]
        public string? ReceiverName { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public DateTime CreatedAt { get; set; }
        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        [Display(Name = "ماهیت مرسوله")]
        public string? PackageTypeName { get; set; }

        [Display(Name = "وزن")]
        public double? ActualWeight { get; set; }
    }
}
