using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmBlogComment
    {

        public int ComID { get; set; }

        [Display(Name = "تاریخ پیام")]
        public DateTime ComDate { get; set; }

        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "نوشتن نام نویسنده پیام الزامی است")]
        public string ComSender { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage ="پیام خود را بنویسید")]
        public string CommentText { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "شماره موبایلتان را وارد نمایید")]
        public string Mobile { get; set; }

        [Display(Name = "ایمیل")]
        public string ComEmail { get; set; }

        [Display(Name = "مورد تأیید است")]
        public bool Approve { get; set; }

        [Display(Name = "حذف شد")]
        public bool IsDeleted { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage ="باید مشخص باشد که این پیام برای کدام یک از پست یا اخبار ثبت می شود")]
        public int BlogID { get; set; }

        [Display(Name = "مربوط به خبر")]
        public string BlogTitle { get; set; }
    }
}
