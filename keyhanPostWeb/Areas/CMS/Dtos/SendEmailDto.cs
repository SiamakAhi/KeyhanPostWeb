using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class SendEmailDto
    {
        [Required]
        public int EmailToId { get; set; }

        [Required(ErrorMessage = "نام خود را بنویسید")]
        public string SenderFullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailTo { get; set; }

        public string EmailSubject { get; set; }

        [Required(ErrorMessage = "پیام خود را برای ما بنویسید")]
        public string EmailBody { get; set; }
        public string EmailFrom { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "شماره تماس خود را وارد نمائید")]
        public string Mobile { get; set; }
    }
}
