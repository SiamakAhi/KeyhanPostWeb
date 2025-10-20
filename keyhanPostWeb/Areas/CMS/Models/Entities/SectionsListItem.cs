namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class SectionsListItem
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Text { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? FooterText { get; set; }
        public string? Image { get; set; }
        public string? altImage { get; set; }
        public string? link1_Title { get; set; }
        public string? link1_Address { get; set; }
        public string? link2_Title { get; set; }
        public string? link2_Address { get; set; }
        public string? link3_Title { get; set; }
        public string? link3_Address { get; set; }

        public int SectionContentID { get; set; }
        public SectionsContent ForSection { get; set; }

    }
}
