namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class pakage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? subtitle { get; set; }
        public string? Description { get; set; }
        public string? footerText { get; set; }
        public string? LinkAddress { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<ProductInPakge> ProductInPakges { get; set; }
    }
}
