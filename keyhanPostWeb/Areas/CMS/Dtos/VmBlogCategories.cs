using System.Collections.Generic;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmBlogCategories
    {
        public VmBlogCategory Category { get; set; }
        public List<VmBlogCategory> Categories { get; set; }
    }
}
