namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class SectionsContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? FooterText { get; set; }
        public string? image { get; set; }
        public string? DeveloperNote { get; set; }

        public int SectionID { get; set; }
        public SitePageAndSection PageOrSection { get; set; }

        public List<SectionsListItem> ListItems { get; set; }
    }
}
