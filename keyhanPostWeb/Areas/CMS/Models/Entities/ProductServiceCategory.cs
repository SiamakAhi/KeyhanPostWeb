using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ProductServiceCategory
    {
        public int Id { get; set; }
        public bool IsProduct { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }

        public virtual List<ProductService> ProductServices { get; set; }
    }
}
