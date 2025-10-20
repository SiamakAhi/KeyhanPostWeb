using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ProductCategory
    {
        public int categoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
