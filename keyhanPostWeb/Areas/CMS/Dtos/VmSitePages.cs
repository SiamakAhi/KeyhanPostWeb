using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmSitePages
    {
        public int Id { get; set; }

        [Display(Name = "کد")]
        public int SectionCode { get; set; }

        [Display(Name = "عنوان")]
        public string SerctionName { get; set; }

        [Display(Name = "Url")]
        public string SectionUrl { get; set; }
    }
}
