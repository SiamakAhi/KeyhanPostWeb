using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductCategory
    {
        public int Id { get; set; }

        [Display(Name ="این دسته شامل محصول است")]
        public bool IsProduct { get; set; }

        [Display(Name = "نام دسته")]
        [Required(ErrorMessage ="نوشتن {0} الزامی است")]
        public string CategoryName { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }
        public int ProductQty { get; set; }

        [Display(Name = "انتخاب تصویر")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "زیر مجموعه این دسته نمایش داده شوند")]
        public bool IsActive { get; set; }

    }
}
