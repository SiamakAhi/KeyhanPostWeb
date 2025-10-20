using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmNewsCategories
    {
        public string name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string image { get; set; }

        [Display(Name = "شرح تصویر")]
        public string AltImage { get; set; }

        public int PostQty { get; set; }
    }
}
