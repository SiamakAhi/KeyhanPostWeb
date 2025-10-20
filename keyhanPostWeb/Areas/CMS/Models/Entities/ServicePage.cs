using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.CMS.Models.Entities
{
    public class ServicePage
    {
        [Key]
        public int Id { get; set; } // شناسه
        public int Priority { get; set; } = 0;
        public string CategoryName { get; set; } // دسته خدمت

        [Required(ErrorMessage = "عنوان خدمت الزامی است.")]
        public string Title { get; set; } // عنوان خدمت

        public string ShortDescription { get; set; } // توصیف کوتاه

        [Required(ErrorMessage = "متن 1 الزامی است.")]
        public string Text1 { get; set; } // متن 1

        public string Text2 { get; set; } // متن 2

        public string Text3 { get; set; } // متن 3

        public string Text4 { get; set; } // متن 4 جدید
        public string Text5 { get; set; } // متن 5 جدید
        public string Text6 { get; set; } // متن 6 جدید
        public string LastText { get; set; } // متن آخر

        public string Image1Path { get; set; } // مسیر تصویر 1
        public string Image2Path { get; set; } // مسیر تصویر 2
        public string Image3Path { get; set; } // مسیر تصویر 3
        public string Image4Path { get; set; } // مسیر تصویر 4 جدید
        public string Image5Path { get; set; } // مسیر تصویر 5 جدید
        public string Image6Path { get; set; } // مسیر تصویر 6 جدید

        public string Image1Description { get; set; } // شرح تصویر 1
        public string Image2Description { get; set; } // شرح تصویر 2
        public string Image3Description { get; set; } // شرح تصویر 3
        public string Image4Description { get; set; } // شرح تصویر 4 جدید
        public string Image5Description { get; set; } // شرح تصویر 5 جدید
        public string Image6Description { get; set; } // شرح تصویر 6 جدید

        public string Link1 { get; set; } // لینک اول (آدرس لینک)
        public string Link1Title { get; set; } // عنوان لینک اول

        public string Link2 { get; set; } // لینک دوم
        public string Link2Title { get; set; } // عنوان لینک دوم

        public string Link3 { get; set; } // لینک سوم
        public string Link3Title { get; set; } // عنوان لینک سوم

        public string Link4 { get; set; } // لینک چهارم (آدرس لینک)
        public string Link4Title { get; set; } // عنوان لینک چهارم

        public string Link5 { get; set; } // لینک پنجم
        public string Link5Title { get; set; } // عنوان لینک پنجم


        //
        //Meta Tag
        public string Meta_description { get; set; }
        public string Meta_keywords { get; set; }
        public string Meta_author { get; set; }
        public string Meta_copyright { get; set; }
        public string Meta_license { get; set; }
        public string Meta_name { get; set; }
        public string Meta_title { get; set; }
    }


}
