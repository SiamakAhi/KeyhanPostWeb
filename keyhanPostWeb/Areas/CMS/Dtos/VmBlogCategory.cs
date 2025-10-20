using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmBlogCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نوشتن نام برای گروه الزامی ست")]
        [Display(Name = "عنوان")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "تصویر")]
        public string? image { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile? imageFile { get; set; }

        [Display(Name = "شرح تصویر")]
        public string? AltImage { get; set; }
    }
}
