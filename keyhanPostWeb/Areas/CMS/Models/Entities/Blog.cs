namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public string? Category { get; set; }
        public string Title { get; set; }
        public string? HeaderText { get; set; }
        public string? MainText { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }
        public string? FooterText { get; set; }
        public string? Image { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Sender { get; set; }
        public bool Approve { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public virtual List<BlogComment> BlogComments { get; set; }
    }
}
