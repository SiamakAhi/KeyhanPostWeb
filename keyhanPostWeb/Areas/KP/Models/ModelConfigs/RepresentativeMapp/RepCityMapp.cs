
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepCityMapp : IEntityTypeConfiguration<RepCity>
    {
        public void Configure(EntityTypeBuilder<RepCity> builder)
        {

            builder.HasOne(n => n.Province)
                .WithMany(n => n.Cities)
                .HasForeignKey(f => f.ProvinceId);

            builder.HasData(
                // استان آذربایجان شرقی
                new RepCity { Id = 1, ProvinceId = 1, CityName = "تبریز" },
                new RepCity { Id = 2, ProvinceId = 1, CityName = "مراغه" },
                new RepCity { Id = 3, ProvinceId = 1, CityName = "مرند" },
                new RepCity { Id = 4, ProvinceId = 1, CityName = "میانه" },
                new RepCity { Id = 5, ProvinceId = 1, CityName = "اهر" },
                new RepCity { Id = 6, ProvinceId = 1, CityName = "سراب" },
                new RepCity { Id = 7, ProvinceId = 1, CityName = "شبستر" },
                new RepCity { Id = 8, ProvinceId = 1, CityName = "بستان‌آباد" },

                // استان آذربایجان غربی
                new RepCity { Id = 9, ProvinceId = 2, CityName = "ارومیه" },
                new RepCity { Id = 10, ProvinceId = 2, CityName = "خوی" },
                new RepCity { Id = 11, ProvinceId = 2, CityName = "میاندوآب" },
                new RepCity { Id = 12, ProvinceId = 2, CityName = "مهاباد" },
                new RepCity { Id = 13, ProvinceId = 2, CityName = "سلماس" },
                new RepCity { Id = 14, ProvinceId = 2, CityName = "بوکان" },
                new RepCity { Id = 15, ProvinceId = 2, CityName = "پیرانشهر" },
                new RepCity { Id = 16, ProvinceId = 2, CityName = "سردشت" },

                // استان اردبیل
                new RepCity { Id = 17, ProvinceId = 3, CityName = "اردبیل" },
                new RepCity { Id = 18, ProvinceId = 3, CityName = "پارس‌آباد" },
                new RepCity { Id = 19, ProvinceId = 3, CityName = "مشگین‌شهر" },
                new RepCity { Id = 20, ProvinceId = 3, CityName = "خلخال" },
                new RepCity { Id = 21, ProvinceId = 3, CityName = "بیله‌سوار" },
                new RepCity { Id = 22, ProvinceId = 3, CityName = "نمین" },
                new RepCity { Id = 23, ProvinceId = 3, CityName = "گرمی" },
                new RepCity { Id = 24, ProvinceId = 3, CityName = "نیر" },

                // استان اصفهان
                new RepCity { Id = 25, ProvinceId = 4, CityName = "اصفهان" },
                new RepCity { Id = 26, ProvinceId = 4, CityName = "کاشان" },
                new RepCity { Id = 27, ProvinceId = 4, CityName = "خمینی‌شهر" },
                new RepCity { Id = 28, ProvinceId = 4, CityName = "نجف‌آباد" },
                new RepCity { Id = 29, ProvinceId = 4, CityName = "فلاورجان" },
                new RepCity { Id = 30, ProvinceId = 4, CityName = "شاهین‌شهر" },
                new RepCity { Id = 31, ProvinceId = 4, CityName = "شهرضا" },
                new RepCity { Id = 32, ProvinceId = 4, CityName = "نایین" },

                // استان البرز
                new RepCity { Id = 33, ProvinceId = 5, CityName = "کرج" },
                new RepCity { Id = 34, ProvinceId = 5, CityName = "نظرآباد" },
                new RepCity { Id = 35, ProvinceId = 5, CityName = "ساوجبلاغ" },
                new RepCity { Id = 36, ProvinceId = 5, CityName = "فردیس" },
                new RepCity { Id = 37, ProvinceId = 5, CityName = "اشتهارد" },
                new RepCity { Id = 38, ProvinceId = 5, CityName = "چهارباغ" },
                new RepCity { Id = 39, ProvinceId = 5, CityName = "طالقان" },
                new RepCity { Id = 40, ProvinceId = 5, CityName = "گرمدره" },

                // استان ایلام
                new RepCity { Id = 41, ProvinceId = 6, CityName = "ایلام" },
                new RepCity { Id = 42, ProvinceId = 6, CityName = "ایوان" },
                new RepCity { Id = 43, ProvinceId = 6, CityName = "دره‌شهر" },
                new RepCity { Id = 44, ProvinceId = 6, CityName = "دهلران" },
                new RepCity { Id = 45, ProvinceId = 6, CityName = "مهران" },
                new RepCity { Id = 46, ProvinceId = 6, CityName = "سرابله" },
                new RepCity { Id = 47, ProvinceId = 6, CityName = "آبدانان" },
                new RepCity { Id = 48, ProvinceId = 6, CityName = "بدره" },

                // استان بوشهر
                new RepCity { Id = 49, ProvinceId = 7, CityName = "بوشهر" },
                new RepCity { Id = 50, ProvinceId = 7, CityName = "دشتستان" },
                new RepCity { Id = 51, ProvinceId = 7, CityName = "دشتی" },
                new RepCity { Id = 52, ProvinceId = 7, CityName = "تنگستان" },
                new RepCity { Id = 53, ProvinceId = 7, CityName = "گناوه" },
                new RepCity { Id = 54, ProvinceId = 7, CityName = "کنگان" },
                new RepCity { Id = 55, ProvinceId = 7, CityName = "جم" },
                new RepCity { Id = 56, ProvinceId = 7, CityName = "دیر" },

                // استان تهران
                new RepCity { Id = 57, ProvinceId = 8, CityName = "تهران" },
                new RepCity { Id = 58, ProvinceId = 8, CityName = "شهریار" },
                new RepCity { Id = 59, ProvinceId = 8, CityName = "ملارد" },
                new RepCity { Id = 60, ProvinceId = 8, CityName = "ری" },
                new RepCity { Id = 61, ProvinceId = 8, CityName = "قدس" },
                new RepCity { Id = 62, ProvinceId = 8, CityName = "اسلام‌شهر" },
                new RepCity { Id = 63, ProvinceId = 8, CityName = "بهارستان" },
                new RepCity { Id = 64, ProvinceId = 8, CityName = "پاکدشت" },

                // استان چهارمحال و بختیاری
                new RepCity { Id = 65, ProvinceId = 9, CityName = "شهرکرد" },
                new RepCity { Id = 66, ProvinceId = 9, CityName = "فارسان" },
                new RepCity { Id = 67, ProvinceId = 9, CityName = "بروجن" },
                new RepCity { Id = 68, ProvinceId = 9, CityName = "لردگان" },
                new RepCity { Id = 69, ProvinceId = 9, CityName = "سامان" },
                new RepCity { Id = 70, ProvinceId = 9, CityName = "اردل" },
                new RepCity { Id = 71, ProvinceId = 9, CityName = "کیار" },
                new RepCity { Id = 72, ProvinceId = 9, CityName = "بن" },

                // استان خراسان جنوبی
                new RepCity { Id = 73, ProvinceId = 10, CityName = "بیرجند" },
                new RepCity { Id = 74, ProvinceId = 10, CityName = "قائن" },
                new RepCity { Id = 75, ProvinceId = 10, CityName = "فردوس" },
                new RepCity { Id = 76, ProvinceId = 10, CityName = "نهبندان" },
                new RepCity { Id = 77, ProvinceId = 10, CityName = "طبس" },
                new RepCity { Id = 78, ProvinceId = 10, CityName = "سربیشه" },
                new RepCity { Id = 79, ProvinceId = 10, CityName = "درمیان" },
                new RepCity { Id = 80, ProvinceId = 10, CityName = "خوسف" },

                // استان خراسان رضوی
                new RepCity { Id = 81, ProvinceId = 11, CityName = "مشهد" },
                new RepCity { Id = 82, ProvinceId = 11, CityName = "نیشابور" },
                new RepCity { Id = 83, ProvinceId = 11, CityName = "سبزوار" },
                new RepCity { Id = 84, ProvinceId = 11, CityName = "تربت‌حیدریه" },
                new RepCity { Id = 85, ProvinceId = 11, CityName = "قوچان" },
                new RepCity { Id = 86, ProvinceId = 11, CityName = "کاشمر" },
                new RepCity { Id = 87, ProvinceId = 11, CityName = "تربت‌جام" },
                new RepCity { Id = 88, ProvinceId = 11, CityName = "چناران" },

                // استان خوزستان
                new RepCity { Id = 89, ProvinceId = 13, CityName = "اهواز" },
                new RepCity { Id = 90, ProvinceId = 13, CityName = "آبادان" },
                new RepCity { Id = 91, ProvinceId = 13, CityName = "خرمشهر" },
                new RepCity { Id = 92, ProvinceId = 13, CityName = "دزفول" },
                new RepCity { Id = 93, ProvinceId = 13, CityName = "شوشتر" },
                new RepCity { Id = 94, ProvinceId = 13, CityName = "بندر ماهشهر" },
                new RepCity { Id = 95, ProvinceId = 13, CityName = "بهبهان" },
                new RepCity { Id = 96, ProvinceId = 13, CityName = "اندیمشک" },

                // استان زنجان
                new RepCity { Id = 97, ProvinceId = 14, CityName = "زنجان" },
                new RepCity { Id = 98, ProvinceId = 14, CityName = "ابهر" },
                new RepCity { Id = 99, ProvinceId = 14, CityName = "خدابنده" },
                new RepCity { Id = 100, ProvinceId = 14, CityName = "خرمدره" },
                new RepCity { Id = 101, ProvinceId = 14, CityName = "سلطانیه" },
                new RepCity { Id = 102, ProvinceId = 14, CityName = "ماه‌نشان" },
                new RepCity { Id = 103, ProvinceId = 14, CityName = "طارم" },
                new RepCity { Id = 104, ProvinceId = 14, CityName = "ایجرود" },

                // استان سمنان
                new RepCity { Id = 105, ProvinceId = 15, CityName = "سمنان" },
                new RepCity { Id = 106, ProvinceId = 15, CityName = "شاهرود" },
                new RepCity { Id = 107, ProvinceId = 15, CityName = "دامغان" },
                new RepCity { Id = 108, ProvinceId = 15, CityName = "گرمسار" },
                new RepCity { Id = 109, ProvinceId = 15, CityName = "مهدیشهر" },
                new RepCity { Id = 110, ProvinceId = 15, CityName = "میامی" },
                new RepCity { Id = 111, ProvinceId = 15, CityName = "سرخه" },
                new RepCity { Id = 112, ProvinceId = 15, CityName = "آرادان" },

                // استان سیستان و بلوچستان
                new RepCity { Id = 113, ProvinceId = 16, CityName = "زاهدان" },
                new RepCity { Id = 114, ProvinceId = 16, CityName = "چابهار" },
                new RepCity { Id = 115, ProvinceId = 16, CityName = "ایرانشهر" },
                new RepCity { Id = 116, ProvinceId = 16, CityName = "سراوان" },
                new RepCity { Id = 117, ProvinceId = 16, CityName = "خاش" },
                new RepCity { Id = 118, ProvinceId = 16, CityName = "زابل" },
                new RepCity { Id = 119, ProvinceId = 16, CityName = "نیک‌شهر" },
                new RepCity { Id = 120, ProvinceId = 16, CityName = "کنارک" },

                // استان فارس
                new RepCity { Id = 121, ProvinceId = 17, CityName = "شیراز" },
                new RepCity { Id = 122, ProvinceId = 17, CityName = "مرودشت" },
                new RepCity { Id = 123, ProvinceId = 17, CityName = "کازرون" },
                new RepCity { Id = 124, ProvinceId = 17, CityName = "جهرم" },
                new RepCity { Id = 125, ProvinceId = 17, CityName = "لارستان" },
                new RepCity { Id = 126, ProvinceId = 17, CityName = "فسا" },
                new RepCity { Id = 127, ProvinceId = 17, CityName = "داراب" },
                new RepCity { Id = 128, ProvinceId = 17, CityName = "نورآباد" },

                // استان قزوین
                new RepCity { Id = 129, ProvinceId = 18, CityName = "قزوین" },
                new RepCity { Id = 130, ProvinceId = 18, CityName = "الوند" },
                new RepCity { Id = 131, ProvinceId = 18, CityName = "آبیک" },
                new RepCity { Id = 132, ProvinceId = 18, CityName = "تاکستان" },
                new RepCity { Id = 133, ProvinceId = 18, CityName = "بوئین‌زهرا" },
                new RepCity { Id = 134, ProvinceId = 18, CityName = "اقبالیه" },
                new RepCity { Id = 135, ProvinceId = 18, CityName = "آوج" },
                new RepCity { Id = 136, ProvinceId = 18, CityName = "محمدیه" },

                // استان قم
                new RepCity { Id = 137, ProvinceId = 19, CityName = "قم" },
                new RepCity { Id = 138, ProvinceId = 19, CityName = "جعفریه" },
                new RepCity { Id = 139, ProvinceId = 19, CityName = "دستجرد" },
                new RepCity { Id = 140, ProvinceId = 19, CityName = "قنوات" },
                new RepCity { Id = 141, ProvinceId = 19, CityName = "کهک" },
                new RepCity { Id = 142, ProvinceId = 19, CityName = "سلفچگان" },
                new RepCity { Id = 143, ProvinceId = 19, CityName = "خلجستان" },
                new RepCity { Id = 144, ProvinceId = 19, CityName = "شهرک قدس" },

                // استان کردستان
                new RepCity { Id = 145, ProvinceId = 20, CityName = "سنندج" },
                new RepCity { Id = 146, ProvinceId = 20, CityName = "سقز" },
                new RepCity { Id = 147, ProvinceId = 20, CityName = "بانه" },
                new RepCity { Id = 148, ProvinceId = 20, CityName = "مریوان" },
                new RepCity { Id = 149, ProvinceId = 20, CityName = "بیجار" },
                new RepCity { Id = 150, ProvinceId = 20, CityName = "دیواندره" },
                new RepCity { Id = 151, ProvinceId = 20, CityName = "قروه" },
                new RepCity { Id = 152, ProvinceId = 20, CityName = "کامیاران" },

                // استان کرمان
                new RepCity { Id = 153, ProvinceId = 21, CityName = "کرمان" },
                new RepCity { Id = 154, ProvinceId = 21, CityName = "رفسنجان" },
                new RepCity { Id = 155, ProvinceId = 21, CityName = "سیرجان" },
                new RepCity { Id = 156, ProvinceId = 21, CityName = "جیرفت" },
                new RepCity { Id = 157, ProvinceId = 21, CityName = "بم" },
                new RepCity { Id = 158, ProvinceId = 21, CityName = "زرند" },
                new RepCity { Id = 159, ProvinceId = 21, CityName = "کهنوج" },
                new RepCity { Id = 160, ProvinceId = 21, CityName = "بافت" },

                // استان کرمانشاه
                new RepCity { Id = 161, ProvinceId = 22, CityName = "کرمانشاه" },
                new RepCity { Id = 162, ProvinceId = 22, CityName = "اسلام‌آباد غرب" },
                new RepCity { Id = 163, ProvinceId = 22, CityName = "قصر شیرین" },
                new RepCity { Id = 164, ProvinceId = 22, CityName = "سنقر" },
                new RepCity { Id = 165, ProvinceId = 22, CityName = "کنگاور" },
                new RepCity { Id = 166, ProvinceId = 22, CityName = "سرپل ذهاب" },
                new RepCity { Id = 167, ProvinceId = 22, CityName = "هرسین" },
                new RepCity { Id = 168, ProvinceId = 22, CityName = "پاوه" },

                // استان کهگیلویه و بویراحمد
                new RepCity { Id = 169, ProvinceId = 23, CityName = "یاسوج" },
                new RepCity { Id = 170, ProvinceId = 23, CityName = "دهدشت" },
                new RepCity { Id = 171, ProvinceId = 23, CityName = "دوگنبدان" },
                new RepCity { Id = 172, ProvinceId = 23, CityName = "سی‌سخت" },
                new RepCity { Id = 173, ProvinceId = 23, CityName = "لیکک" },
                new RepCity { Id = 174, ProvinceId = 23, CityName = "لنده" },
                new RepCity { Id = 175, ProvinceId = 23, CityName = "چرام" },
                new RepCity { Id = 176, ProvinceId = 23, CityName = "باشت" },

                // استان گلستان
                new RepCity { Id = 177, ProvinceId = 24, CityName = "گرگان" },
                new RepCity { Id = 178, ProvinceId = 24, CityName = "گنبد کاووس" },
                new RepCity { Id = 179, ProvinceId = 24, CityName = "علی‌آباد کتول" },
                new RepCity { Id = 180, ProvinceId = 24, CityName = "آق‌قلا" },
                new RepCity { Id = 181, ProvinceId = 24, CityName = "بندر ترکمن" },
                new RepCity { Id = 182, ProvinceId = 24, CityName = "مینودشت" },
                new RepCity { Id = 183, ProvinceId = 24, CityName = "آزادشهر" },
                new RepCity { Id = 184, ProvinceId = 24, CityName = "کلاله" },

                // استان گیلان
                new RepCity { Id = 185, ProvinceId = 25, CityName = "رشت" },
                new RepCity { Id = 186, ProvinceId = 25, CityName = "انزلی" },
                new RepCity { Id = 187, ProvinceId = 25, CityName = "لاهیجان" },
                new RepCity { Id = 188, ProvinceId = 25, CityName = "لنگرود" },
                new RepCity { Id = 189, ProvinceId = 25, CityName = "آستارا" },
                new RepCity { Id = 190, ProvinceId = 25, CityName = "رودسر" },
                new RepCity { Id = 191, ProvinceId = 25, CityName = "صومعه‌سرا" },
                new RepCity { Id = 192, ProvinceId = 25, CityName = "تالش" },

                // استان لرستان
                new RepCity { Id = 193, ProvinceId = 26, CityName = "خرم‌آباد" },
                new RepCity { Id = 194, ProvinceId = 26, CityName = "بروجرد" },
                new RepCity { Id = 195, ProvinceId = 26, CityName = "دورود" },
                new RepCity { Id = 196, ProvinceId = 26, CityName = "کوهدشت" },
                new RepCity { Id = 197, ProvinceId = 26, CityName = "الیگودرز" },
                new RepCity { Id = 198, ProvinceId = 26, CityName = "نورآباد" },
                new RepCity { Id = 199, ProvinceId = 26, CityName = "پلدختر" },
                new RepCity { Id = 200, ProvinceId = 26, CityName = "ازنا" },

                // استان مازندران
                new RepCity { Id = 201, ProvinceId = 27, CityName = "ساری" },
                new RepCity { Id = 202, ProvinceId = 27, CityName = "بابل" },
                new RepCity { Id = 203, ProvinceId = 27, CityName = "آمل" },
                new RepCity { Id = 204, ProvinceId = 27, CityName = "قائم‌شهر" },
                new RepCity { Id = 205, ProvinceId = 27, CityName = "بهشهر" },
                new RepCity { Id = 206, ProvinceId = 27, CityName = "نور" },
                new RepCity { Id = 207, ProvinceId = 27, CityName = "نوشهر" },
                new RepCity { Id = 208, ProvinceId = 27, CityName = "چالوس" },

                // استان مرکزی
                new RepCity { Id = 209, ProvinceId = 28, CityName = "اراک" },
                new RepCity { Id = 210, ProvinceId = 28, CityName = "ساوه" },
                new RepCity { Id = 211, ProvinceId = 28, CityName = "خمین" },
                new RepCity { Id = 212, ProvinceId = 28, CityName = "محلات" },
                new RepCity { Id = 213, ProvinceId = 28, CityName = "دلیجان" },
                new RepCity { Id = 214, ProvinceId = 28, CityName = "شازند" },
                new RepCity { Id = 215, ProvinceId = 28, CityName = "تفرش" },
                new RepCity { Id = 216, ProvinceId = 28, CityName = "آشتیان" },

                // استان هرمزگان
                new RepCity { Id = 217, ProvinceId = 29, CityName = "بندرعباس" },
                new RepCity { Id = 218, ProvinceId = 29, CityName = "قشم" },
                new RepCity { Id = 219, ProvinceId = 29, CityName = "کیش" },
                new RepCity { Id = 220, ProvinceId = 29, CityName = "بندر لنگه" },
                new RepCity { Id = 221, ProvinceId = 29, CityName = "میناب" },
                new RepCity { Id = 222, ProvinceId = 29, CityName = "رودان" },
                new RepCity { Id = 223, ProvinceId = 29, CityName = "جاسک" },
                new RepCity { Id = 224, ProvinceId = 29, CityName = "حاجی‌آباد" },

                // استان همدان
                new RepCity { Id = 225, ProvinceId = 30, CityName = "همدان" },
                new RepCity { Id = 226, ProvinceId = 30, CityName = "ملایر" },
                new RepCity { Id = 227, ProvinceId = 30, CityName = "نهاوند" },
                new RepCity { Id = 228, ProvinceId = 30, CityName = "اسدآباد" },
                new RepCity { Id = 229, ProvinceId = 30, CityName = "تویسرکان" },
                new RepCity { Id = 230, ProvinceId = 30, CityName = "کبودرآهنگ" },
                new RepCity { Id = 231, ProvinceId = 30, CityName = "رزن" },
                new RepCity { Id = 232, ProvinceId = 30, CityName = "فامنین" },

                // استان یزد
                new RepCity { Id = 233, ProvinceId = 31, CityName = "یزد" },
                new RepCity { Id = 234, ProvinceId = 31, CityName = "میبد" },
                new RepCity { Id = 235, ProvinceId = 31, CityName = "اردکان" },
                new RepCity { Id = 236, ProvinceId = 31, CityName = "بافق" },
                new RepCity { Id = 237, ProvinceId = 31, CityName = "مهریز" },
                new RepCity { Id = 238, ProvinceId = 31, CityName = "ابرکوه" },
                new RepCity { Id = 239, ProvinceId = 31, CityName = "تفت" },
                new RepCity { Id = 240, ProvinceId = 31, CityName = "خاتم" }


            );

        }


    }
}
