using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{
    public class VmProductAndService
    {

        public int ProductID { get; set; }

        [Display(Name = "دسته")]
        [Required(ErrorMessage = "انتخاب دسته الزامی است")]
        public int CategoryID { get; set; }

        [Display(Name = "دسته")]
        public string CategoryName { get; set; }

        [Display(Name = "عنوان کوتاه")]
        [Required(ErrorMessage = "نوشتن عنوان برای محصول الزامی است")]
        public string ShortTitle { get; set; }

        [Display(Name = "عنوان کامل")]
        public string LongTitle { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "پاراگراف 1")]
        public string MainText { get; set; }

        [Display(Name = "پاراگراف 2")]
        public string Subtext1 { get; set; }

        [Display(Name = "پاراگراف 3")]
        public string Subtext2 { get; set; }

        [Display(Name = "پاراگراف 4")]
        public string Subtext3 { get; set; }



        [Display(Name = "متن آخر")]
        public string FooterText { get; set; }

        [Display(Name = "قیمت")]
        public Int64? price { get; set; }

        [Display(Name = "تخفیف")]
        public Int64? discount { get; set; }

        [Display(Name = "قیمت نهایی")]
        public Int64? FinalPrice { get; set; }


        [Display(Name = "قیمت نمایش داده شود")]
        public bool AlowShowPrice { get; set; }

        [Display(Name = "در صخحه اصلی نمایش داده شود")]
        public bool ShowInHome { get; set; }

        [Display(Name = "محصول ویژه")]
        public bool SpecialProduct { get; set; }

        [Display(Name = "قابل ارائه")]
        public bool IsAvalable { get; set; }

        public List<VmProductAndServiceImages> images { get; set; }



    }
}
