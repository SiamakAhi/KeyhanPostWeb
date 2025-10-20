namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class SitePageAndSection
    {
        public int Id { get; set; }
        public int SectionCode { get; set; }
        public string? SerctionName { get; set; }
        public string? SectionUrl { get; set; }

        public List<SectionsContent> SectionsContents { get; set; }
    }
}
