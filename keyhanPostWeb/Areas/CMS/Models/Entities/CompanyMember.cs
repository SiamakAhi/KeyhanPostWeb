using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class CompanyMember
    {
        [Key]
        public int id { get; set; }
        public int Priority { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string Semat { get; set; }
        public bool IsManager { get; set; }
        public string phone { get; set; }
        public string Mobile { get; set; }
        public string email { get; set; }
        public string images { get; set; }

    }
}
