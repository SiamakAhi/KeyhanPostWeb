using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VM_Gallery
    {
        public int photoID { get; set; }

        [DisplayName("عنوان")]
        [Required(ErrorMessage = "عنوان عکس را بنویسید")]
        public string Title { get; set; }

        [DisplayName("شرح")]
        public string Description { get; set; }

        [DisplayName("انتخاب فایل")]
        public string FileName { get; set; }

        [DisplayName("انتخاب فایل")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("دسته")]
        public int? CategoryID { get; set; }

        [DisplayName("دسته")]
        public string CategoryName { get; set; }

        [DisplayName("پروژه")]
        public int? ProjectID { get; set; }

        [DisplayName("پروژه")]
        public string ProjectName { get; set; }

        [DisplayName("قابل رویت")]
        public bool Visible { get; set; }

        [DisplayName("تصویر اصلی")]
        public bool IsMainPic { get; set; }
    }
}
