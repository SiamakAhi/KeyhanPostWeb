using System;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class VisitorLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime VisitTime { get; set; }
        public string IpAddress { get; set; }
        public string VisitorToken { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
        public string PageUrl { get; set; }
        public string Referrer { get; set; }
    }
}
