using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class OrderFilterDto
    {
        public int? StatusId { get; set; }        // فیلتر بر اساس وضعیت
        public int? OriginCityId { get; set; }    // فیلتر بر اساس شهر مبدا
        public int? DestinationCityId { get; set; } // فیلتر بر اساس شهر مقصد
        public string? SenderName { get; set; }   // فیلتر بر اساس نام فرستنده
        public string? OriginCountryName {  get; set; }   // فیلتر بر اساس کشور مبدا
        public string? DestinationCountryName { get; set; }   // فیلتر بر اساس کشور مقصد
        public string? ReceiverName { get; set; } // فیلتر بر اساس نام گیرنده
        
        public DateTime? FromDate { get; set; }
        public string? StrFromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? StrToDate { get; set; }// پایان بازه تاریخ
    }
}
