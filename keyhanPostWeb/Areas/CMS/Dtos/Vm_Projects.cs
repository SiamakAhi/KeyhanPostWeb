using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class Vm_Projects
    {
        public List<VmProject> Projects { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int RowPerPage { get; set; }
    }
}
