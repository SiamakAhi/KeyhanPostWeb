namespace keyhanPostWeb.Areas.KP.Dto
{
    public class WaybillHistoryItemDto
    {
        public string Title { get; set; }       // فارسی
        public string TitleEn { get; set; }     // انگلیسی
        public string Description { get; set; } // توضیحات
        public DateTime ChangedAt { get; set; }
        public string Color { get; set; }
    }
}
