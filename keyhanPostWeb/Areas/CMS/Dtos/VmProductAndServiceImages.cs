using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductAndServiceImages
    {
        public int Id { get; set; }

        [Display(Name = "محصول")]
        [Required(ErrorMessage = "نوشتن نام برای تصویر الزامی ست")]
        public int ProductID { get; set; }

        [Display(Name = "دسته")]
        public int CategoryID { get; set; }

        [Display(Name = "محصول")]
        public string ProductName { get; set; }

        [Display(Name = "دسته")]
        public string CategoryName { get; set; }

        [Display(Name = "نام")]
        public string name { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage ="انتخاب تصویر الزامیست")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "الویت")]
        public int Priority { get; set; }

        [Display(Name = "تصویر اصلی")]
        public bool IsMainImage { get; set; }

        [Display(Name = "در سایت نمایش داده شود")]
        public bool AllowToShow { get; set; }
    }
}
