namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class PhotoGallery
    {
        public int photoID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string FileName { get; set; }
        public int? CategoryID { get; set; }
        public int? BlogID { get; set; }
        public bool Visible { get; set; } = true;
        public int? ProjectID { get; set; }
        public bool IsMainPic { get; set; }

    }
}
