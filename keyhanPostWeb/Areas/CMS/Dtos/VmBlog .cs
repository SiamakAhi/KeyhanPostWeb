using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmBlog
    {
        public int Id { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime PostDate { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "انتخاب {0} الزامی است")]
        public string? Category { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        public string? Title { get; set; }

        [Display(Name = "تیتر خبر")]
        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        public string? HeaderText { get; set; }

        [Display(Name = "متن اصلی ")]
        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        public string? MainText { get; set; }

        [Display(Name = "شرح خبر - پاراگراف اول ")]
        public string? Text2 { get; set; }

        [Display(Name = "شرح خبر - پاراگراف دوم ")]
        public string? Text3 { get; set; }

        [Display(Name = "پی نوشت ")]
        public string? FooterText { get; set; }

        [Display(Name = "تصویر اصلی")]
        public string? Image { get; set; }

        [Display(Name = "تصویر دوم")]
        public string? Image1 { get; set; }

        [Display(Name = "تصویر سوم")]
        public string? Image2 { get; set; }

        [Display(Name = "تصویر اصلی")]
        [Required(ErrorMessage = "انتخاب تصویر اصلی برای هر خبر الزامی می باشد")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "تصویر دوم")]
        public IFormFile? Image1File { get; set; }

        [Display(Name = "تصویر سوم")]
        public IFormFile? Image2File { get; set; }

        [Display(Name = "ارسال کننده ")]
        public string? Sender { get; set; }

        [Display(Name = "تعداد نظرات")]
        public int CommentQty { get; set; } = 0;

        [Display(Name = "منتشر شود")]
        public bool Approve { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "پیام ها")]
        public List<VmBlogComment>? Comments { get; set; }
    }
}
