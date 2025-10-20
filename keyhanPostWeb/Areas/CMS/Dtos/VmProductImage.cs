using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductImage
    {
        public VmProductAndService productOrService { get; set; }
        public VmProductAndServiceImages VmImage { get; set; }

    }
}
