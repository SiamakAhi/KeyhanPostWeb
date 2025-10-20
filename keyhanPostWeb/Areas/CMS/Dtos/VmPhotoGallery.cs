using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmPhotoGallery
    {
        public int photoID { get; set; }

        [Display(Name="عنوان")]
        public string Title { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string FileName { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage ="انتخاب تصویر الزامیست")]
        public IFormFile ImaheFile { get; set; }

        [Display(Name = "دسته")]
        public int? CategoryID { get; set; }

        [Display(Name = "قابل نمایش")]
        public bool Visible { get; set; }
    }
}
