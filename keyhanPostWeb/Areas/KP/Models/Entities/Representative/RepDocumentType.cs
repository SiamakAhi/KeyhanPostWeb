using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepDocumentType
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "عنوان مدرک")]
        public string DocumentTitle { get; set; } // عنوان مدرک

        [Display(Name = "امتیاز بارگذاری")]
        public int UploadScore { get; set; } // امتیاز بارگذاری مدرک

        [Display(Name = "کد مدرک")]
        public int DocumentCode { get; set; } // کد مدرک
    }
}
