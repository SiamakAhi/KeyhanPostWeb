using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class BlogCategory
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "تصویر")]
        public string? image { get; set; }

        [Display(Name = "شرح تصویر")]
        public string? AltImage { get; set; }
    }
}
