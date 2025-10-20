using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmSectionContent
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نوشتن عنوان الزامی است")]
        public string? Title { get; set; }

        [Display(Name = "زیرعنوان")]
        public string? Subtitle { get; set; }
        [Display(Name = "متن اصلی")]
        public string? Text1 { get; set; }
        [Display(Name = "بخش دوم متن")]
        public string? Text2 { get; set; }
        [Display(Name = "نوشته انتهایی")]
        public string? FooterText { get; set; }
        [Display(Name = "تصویر")]
        public string? image { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile? imageFile { get; set; }

        [Display(Name = "مربوط به بخش")]
        public int SectionID { get; set; }
        public string? SectionName { get; set; }

        [Display(Name = "آیتم ها")]
        public List<VmSectionListItem>? listItems { get; set; }
    }
}
