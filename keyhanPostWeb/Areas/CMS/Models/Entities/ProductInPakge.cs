using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ProductInPakge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string FooterText { get; set; }
        public string Icon { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string unitCount { get; set; }
        public decimal AmountInPakage { get; set; }
        public int BasicPrice { get; set; }
        public bool AlowShowPrice { get; set; }
        public bool ShowInHome { get; set; }
        public bool SpecialProduct { get; set; }
        public bool IsAvalable { get; set; }

        public int PakageId { get; set; }
        public int ProductId { get; set; }
        public virtual pakage Pakage { get; set; }
        public virtual ProductService Product { get; set; }
    }
}
