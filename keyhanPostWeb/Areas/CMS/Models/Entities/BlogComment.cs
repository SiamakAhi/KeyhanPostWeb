namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class BlogComment
    {
        public int ComID { get; set; }
        public DateTime ComDate { get; set; }
        public string? ComSender { get; set; }
        public string? CommentText { get; set; }
        public string? Mobile { get; set; }
        public string? ComEmail { get; set; }
        public bool Approve { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        public int BlogID { get; set; }
        public Blog Blog { get; set; }

    }
}
