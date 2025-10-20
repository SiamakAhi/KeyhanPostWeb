using keyhanPostWeb.Areas.CMS.Models.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProject
    {
        public int projectID { get; set; }

        [Required(ErrorMessage = "عنوان پروژه را بنویسید")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("شرح")]
        public string Description { get; set; }

        [DisplayName("متن 2")]
        public string Description2 { get; set; }

        [DisplayName("متن 3")]
        public string Description3 { get; set; }

        [DisplayName("متن 4")]
        public string Description4 { get; set; }

        [DisplayName("متن آخر")]
        public string FooterText { get; set; }



        [DisplayName("توضیحات بیشتر")]
        public string MoreDescription { get; set; }

        [DisplayName("کارفرما")]
        [Required(ErrorMessage = "نام کارفرما را بنویسید")]
        public string Customer { get; set; }

        [DisplayName("تاریخ شروع")]
        public string StartDate { get; set; }

        [DisplayName("تاریخ شروع")]
        public string EndDate { get; set; }

        [DisplayName("مدت زمان اجرا")]
        public string Duration { get; set; }

        [DisplayName("محصول یا خدمت")]
        public int? ProductID { get; set; }

        [DisplayName("محصول یا خدمت")]
        public string ProductName { get; set; }

        [DisplayName("تصویر اصلی")]
        public string Image { get; set; }

        [DisplayName("تصویر اصلی")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("تصاویر پروژ]")]
        public List<ProjectImage> Galleries { get; set; }
    }
}
