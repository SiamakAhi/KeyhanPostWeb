using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VM_GalleryListView
    {
        public List<VM_Gallery> Galleries { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int RowPerPage { get; set; }
    }
}
