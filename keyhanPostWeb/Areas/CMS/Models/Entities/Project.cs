using System.Collections.Generic;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class Project
    {
        public int projectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string FooterText { get; set; }
        public string Customer { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public virtual List<ProjectImage> Images { get; set; }
    }
}
