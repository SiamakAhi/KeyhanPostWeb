using System.ComponentModel;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class InOrderFilterDto
    {
        public int? StatusId { get; set; }        // فیلتر بر اساس وضعیت
        public string? RequesterName { get; set; }   // فیلتر بر اساس نام 
        public string? OriginCountryName { get; set; }   // فیلتر بر اساس کشور مبدا
        public string? DestinationCountryName { get; set; }   // فیلتر بر اساس کشور مقصد
        public string? ReceiverName { get; set; } // فیلتر بر اساس نام گیرنده
       


        public DateTime? FromDate { get; set; }
        public string? StrFromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? StrToDate { get; set; }// پایان بازه تاریخ
    }
}
