using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductsListView
    {
        public List<VmProductAndService> productAndServices { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int RowPerPage { get; set; }
    }
}
