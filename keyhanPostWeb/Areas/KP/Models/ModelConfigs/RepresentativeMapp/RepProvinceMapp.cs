
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepProvinceMapp : IEntityTypeConfiguration<RepProvince>
    {
        public void Configure(EntityTypeBuilder<RepProvince> builder)
        {
            builder.HasData(
                new RepProvince { Id = 1, ProvinceCode = 10, ProvinceName = "آذربایجان شرقی" },
                new RepProvince { Id = 2, ProvinceCode = 11, ProvinceName = "آذربایجان غربی" },
                new RepProvince { Id = 3, ProvinceCode = 12, ProvinceName = "اردبیل" },
                new RepProvince { Id = 4, ProvinceCode = 13, ProvinceName = "اصفهان" },
                new RepProvince { Id = 5, ProvinceCode = 14, ProvinceName = "البرز" },
                new RepProvince { Id = 6, ProvinceCode = 15, ProvinceName = "ایلام" },
                new RepProvince { Id = 7, ProvinceCode = 16, ProvinceName = "بوشهر" },
                new RepProvince { Id = 8, ProvinceCode = 17, ProvinceName = "تهران" },
                new RepProvince { Id = 9, ProvinceCode = 18, ProvinceName = "چهارمحال و بختیاری" },
                new RepProvince { Id = 10, ProvinceCode = 19, ProvinceName = "خراسان جنوبی" },
                new RepProvince { Id = 11, ProvinceCode = 20, ProvinceName = "خراسان رضوی" },
                new RepProvince { Id = 12, ProvinceCode = 21, ProvinceName = "خراسان شمالی" },
                new RepProvince { Id = 13, ProvinceCode = 22, ProvinceName = "خوزستان" },
                new RepProvince { Id = 14, ProvinceCode = 23, ProvinceName = "زنجان" },
                new RepProvince { Id = 15, ProvinceCode = 24, ProvinceName = "سمنان" },
                new RepProvince { Id = 16, ProvinceCode = 25, ProvinceName = "سیستان و بلوچستان" },
                new RepProvince { Id = 17, ProvinceCode = 26, ProvinceName = "فارس" },
                new RepProvince { Id = 18, ProvinceCode = 27, ProvinceName = "قزوین" },
                new RepProvince { Id = 19, ProvinceCode = 28, ProvinceName = "قم" },
                new RepProvince { Id = 20, ProvinceCode = 29, ProvinceName = "کردستان" },
                new RepProvince { Id = 21, ProvinceCode = 30, ProvinceName = "کرمان" },
                new RepProvince { Id = 22, ProvinceCode = 31, ProvinceName = "کرمانشاه" },
                new RepProvince { Id = 23, ProvinceCode = 32, ProvinceName = "کهگیلویه و بویراحمد" },
                new RepProvince { Id = 24, ProvinceCode = 33, ProvinceName = "گلستان" },
                new RepProvince { Id = 25, ProvinceCode = 34, ProvinceName = "گیلان" },
                new RepProvince { Id = 26, ProvinceCode = 35, ProvinceName = "لرستان" },
                new RepProvince { Id = 27, ProvinceCode = 36, ProvinceName = "مازندران" },
                new RepProvince { Id = 28, ProvinceCode = 37, ProvinceName = "مرکزی" },
                new RepProvince { Id = 29, ProvinceCode = 38, ProvinceName = "هرمزگان" },
                new RepProvince { Id = 30, ProvinceCode = 39, ProvinceName = "همدان" },
                new RepProvince { Id = 31, ProvinceCode = 40, ProvinceName = "یزد" }
            );
        }
    }
}
