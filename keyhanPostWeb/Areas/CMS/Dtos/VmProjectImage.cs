using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProjectImage
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }

        [DisplayName("عنوان")]
        public string name { get; set; }

        [DisplayName("شرح تصویر")]
        public string Description { get; set; }

        [DisplayName("الویت")]
        public int Priority { get; set; }

        [DisplayName("بعنوان تصویر اصلی نمایش داده شود")]
        public bool IsMainImage { get; set; }

        [DisplayName("نمایش داده شود")]
        public bool AllowToShow { get; set; }

        [DisplayName("تصویر")]
      
        public string Image { get; set; }

        [DisplayName("تصویر")]
        [Required(ErrorMessage = "تصویری انتحاب نشده است")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("پروژ")]
        [Required(ErrorMessage = "عنوان پروژه را بنویسید")]
        public int ProjectId { get; set; }
    }
}
