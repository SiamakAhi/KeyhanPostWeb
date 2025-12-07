using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class GetInOrdersVm
    {
        public int Id { get; set; }

        //عادی=1
        //الکترونیکی=2
        //پاکت=3
        //فاسد شدنی=4
        //5=کالبد متوفی
        //6=حیوان خانگی

        [Display(Name = "ماهیت مرسوله")]
        public string? PackageTypeName { get; set; }


        [Display(Name = "کشور مبدا")]
        public string? OriginCountryName { get; set; }

        [Display(Name = "کشور مقصد")]
        public string? DestinationCountryName { get; set; }


        [DisplayName("وزن واقعی (کیلوگرم)")]

        public double? ActualWeight { get; set; }

        // --- اطلاعات درخواست کننده ---
        [DisplayName("نام و نام خانوادگی درخواست‌کننده")]

        public string? RequesterName { get; set; }


        [DisplayName("شماره تماس درخواست‌کننده")]

        public string? RequesterMobile { get; set; }


        [DisplayName("شهر درخواست‌کننده")]
        public string? RequesterCityName { get; set; }

        [DisplayName("کد رهگیری")]
        public string? TrackingCode { get; set; }

        [DisplayName("تاریخ ثبت سفارش")]
        public DateTime CreatedAt { get; set; }

        // --- وضعیت سفارش ---
        [DisplayName("وضعیت سفارش")]
        public string OrderStatus { get; set; }

    }
}
