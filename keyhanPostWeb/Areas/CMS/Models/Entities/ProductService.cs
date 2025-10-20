using System;
using System.Collections.Generic;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ProductService
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string MainText { get; set; }
        public string Subtext1 { get; set; }
        public string Subtext2 { get; set; }
        public string Subtext3 { get; set; }
        public string FooterText { get; set; }
        public long price { get; set; }
        public long discount { get; set; }
        public long FinalPrice { get; set; }
        public bool AlowShowPrice { get; set; }
        public bool ShowInHome { get; set; }
        public bool SpecialProduct { get; set; }
        public bool IsAvalable { get; set; }

        public int ProductCategoryID { get; set; }
        public virtual ProductServiceCategory ProductCategory { get; set; }

        public virtual List<ProductServiceImage> ProductServiceImages { get; set; }
        public ICollection<Project> Projects { get; set; }

        public virtual ICollection<ProductInPakge> ProductInPakges { get; set; }

    }
}
