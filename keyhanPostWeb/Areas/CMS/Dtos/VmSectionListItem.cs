using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmSectionListItem
    {
        public int Id { get; set; }
        public int ContentID { get; set; }
        public int SectionID { get; set; }

        [Display(Name = "الویت")]
        public int Priority { get; set; }

        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "زیرعنوان")]
        public string? Subtitle { get; set; }

        [Display(Name = "متن اصلی")]
        public string? Text { get; set; }

        [Display(Name = "متن دوم")]
        public string? Text1 { get; set; }

        [Display(Name = "متن سوم")]
        public string? Text2 { get; set; }

        [Display(Name = "متن پایانی")]
        public string? FooterText { get; set; }

        [Display(Name = "تصویر")]
        public string? Image { get; set; }

        [Display(Name = "شرح تصویر")]
        public string? altImage { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile? ImageFile { get; set; }


        [Display(Name = "عنوان")]
        public string? link1_Title { get; set; }

        [Display(Name = "آدرس")]
        public string? link1_Address { get; set; }

        [Display(Name = "عنوان")]
        public string? link2_Title { get; set; }

        [Display(Name = "آدرس")]
        public string? link2_Address { get; set; }

        [Display(Name = "عنوان")]
        public string? link3_Title { get; set; }

        [Display(Name = "آدرس")]
        public string? link3_Address { get; set; }

    }
}
