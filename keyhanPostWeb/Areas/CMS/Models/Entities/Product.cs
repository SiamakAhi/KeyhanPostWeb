namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ShortTitle { get; set; }
        public string LongTitle { get; set; }
        public string Description { get; set; }
        public string MainText { get; set; }
        public string Subtext1 { get; set; }
        public string Subtext2 { get; set; }
        public string Subtext3 { get; set; }
        public string FooterText { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public int FinalPrice { get; set; }
        public bool AlowShowPrice { get; set; }
        public bool ShowInHome { get; set; }
        public bool SpecialProduct { get; set; }
        public bool IsAvalable { get; set; }
        public int CategoryID { get; set; }
        public ProductCategory Category { get; set; }

    }
}
