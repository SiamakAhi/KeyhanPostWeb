using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Dtos
{


    public class ServicePageViewModel
    {
        public int Id { get; set; } // شناسه

        [Display(Name = "الویت نمایش در صفحه")]
        public int Priority { get; set; } = 0;

        [Display(Name = "دسته خدمت")]
        public string CategoryName { get; set; } // دسته خدمت

        [Required(ErrorMessage = "عنوان خدمت الزامی است.")]
        [Display(Name = "عنوان خدمت")]
        public string Title { get; set; } // عنوان خدمت

        [Display(Name = "توصیف کوتاه")]
        public string ShortDescription { get; set; } // توصیف کوتاه

        [Required(ErrorMessage = "متن 1 الزامی است.")]
        [Display(Name = "متن اصلی")]
        public string Text1 { get; set; } // متن 1

        [Display(Name = "متن 2")]
        public string Text2 { get; set; } // متن 2

        [Display(Name = "متن 3")]
        public string Text3 { get; set; } // متن 3

        [Display(Name = "متن 4 ")]
        public string Text4 { get; set; } // متن 4 جدید

        [Display(Name = "متن 5 ")]
        public string Text5 { get; set; } // متن 5 جدید

        [Display(Name = "متن 6 ")]
        public string Text6 { get; set; } // متن 6 جدید

        [Display(Name = "متن پایانی")]
        public string LastText { get; set; } // متن آخر

        [Display(Name = "مسیر تصویر 1")]
        public string Image1Path { get; set; } // مسیر تصویر 1
        public IFormFile ImageFile1 { get; set; }

        [Display(Name = "مسیر تصویر 2")]
        public string Image2Path { get; set; } // مسیر تصویر 2
        public IFormFile ImageFile2 { get; set; }

        [Display(Name = "مسیر تصویر 3")]
        public string Image3Path { get; set; } // مسیر تصویر 3
        public IFormFile ImageFile3 { get; set; }

        [Display(Name = "مسیر تصویر 4 جدید")]
        public string Image4Path { get; set; } // مسیر تصویر 4 جدید
        public IFormFile ImageFile4 { get; set; }

        [Display(Name = "مسیر تصویر 5 جدید")]
        public string Image5Path { get; set; } // مسیر تصویر 5 جدید
        public IFormFile ImageFile5 { get; set; }

        [Display(Name = "مسیر تصویر 6 جدید")]
        public string Image6Path { get; set; } // مسیر تصویر 6 جدید
        public IFormFile ImageFile6 { get; set; }

        [Display(Name = "شرح تصویر 1")]
        public string Image1Description { get; set; } // شرح تصویر 1

        [Display(Name = "شرح تصویر 2")]
        public string Image2Description { get; set; } // شرح تصویر 2

        [Display(Name = "شرح تصویر 3")]
        public string Image3Description { get; set; } // شرح تصویر 3

        [Display(Name = "شرح تصویر 4 جدید")]
        public string Image4Description { get; set; } // شرح تصویر 4 جدید

        [Display(Name = "شرح تصویر 5 جدید")]
        public string Image5Description { get; set; } // شرح تصویر 5 جدید

        [Display(Name = "شرح تصویر 6 جدید")]
        public string Image6Description { get; set; } // شرح تصویر 6 جدید

        [Display(Name = "لینک اول (آدرس لینک)")]
        public string Link1 { get; set; } // لینک اول (آدرس لینک)

        [Display(Name = "عنوان لینک اول")]
        public string Link1Title { get; set; } // عنوان لینک اول

        [Display(Name = "لینک دوم")]
        public string Link2 { get; set; } // لینک دوم

        [Display(Name = "عنوان لینک دوم")]
        public string Link2Title { get; set; } // عنوان لینک دوم

        [Display(Name = "لینک سوم")]
        public string Link3 { get; set; } // لینک سوم

        [Display(Name = "عنوان لینک سوم")]
        public string Link3Title { get; set; } // عنوان لینک سوم

        [Display(Name = "لینک چهارم (آدرس لینک)")]
        public string Link4 { get; set; } // لینک چهارم (آدرس لینک)

        [Display(Name = "عنوان لینک چهارم")]
        public string Link4Title { get; set; } // عنوان لینک چهارم

        [Display(Name = "لینک پنجم")]
        public string Link5 { get; set; } // لینک پنجم

        [Display(Name = "عنوان لینک پنجم")]
        public string Link5Title { get; set; } // عنوان لینک پنجم


        //Meta Tag

        [Display(Name = "شرح")]
        public string Meta_description { get; set; }
        [Display(Name = "کلیدواژه ها")]
        public string Meta_keywords { get; set; }
        [Display(Name = "تهیه کننده")]
        public string Meta_author { get; set; }
        [Display(Name = "کپی رایت")]
        public string Meta_copyright { get; set; }
        [Display(Name = "مجوز")]
        public string Meta_license { get; set; }
        [Display(Name = "نام")]
        public string Meta_name { get; set; }
        [Display(Name = "عنوان صفحه")]
        public string Meta_title { get; set; }



    }

}
