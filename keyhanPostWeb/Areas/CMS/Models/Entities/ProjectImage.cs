using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsMainImage { get; set; }
        public bool AllowToShow { get; set; }
        public string Image { get; set; }

        public int projectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
