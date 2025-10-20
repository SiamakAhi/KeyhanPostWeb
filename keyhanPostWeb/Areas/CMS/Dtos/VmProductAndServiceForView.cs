using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductAndServiceForView
    {

        public int ProductID { get; set; }

        [Display(Name = "دسته")]
        public int CategoryID { get; set; } 

        [Display(Name = "دسته")]
        public string CategoryName { get; set; }

        [Display(Name ="عنوان کوتاه")]
        public string ShortTitle { get; set; }

        [Display(Name = "عنوان کامل")]
        public string LongTitle { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        public Int64? price { get; set; }

        [Display(Name = "تخفیف")]
        public Int64? discount { get; set; }

        [Display(Name = "قیمت نهایی")]
        public Int64? FinalPrice { get; set; }

        [Display(Name = "در صخحه اصلی نمایش داده شود")]
        public bool ShowInHome { get; set; }

        [Display(Name = "محصول ویژه")]
        public bool SpecialProduct { get; set; }

        [Display(Name = "قابل ارائه")]
        public bool IsAvalable { get; set; }

        public List<VmProductAndServiceImages> images { get; set; }



    }
}
