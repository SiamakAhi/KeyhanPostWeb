namespace keyhanPostWeb.Areas.KP.Dto
{
    public class OrderFilterDto
    {
        public int? StatusId { get; set; }        // فیلتر بر اساس وضعیت
        public int? OriginCityId { get; set; }    // فیلتر بر اساس شهر مبدا
        public int? DestinationCityId { get; set; } // فیلتر بر اساس شهر مقصد
        public string? SenderName { get; set; }   // فیلتر بر اساس نام فرستنده
        public string? ReceiverName { get; set; } // فیلتر بر اساس نام گیرنده
        public DateTime? FromDate { get; set; }   // شروع بازه تاریخ
        public DateTime? ToDate { get; set; }     // پایان بازه تاریخ
    }
}
