using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class WaybillStatusMapp : IEntityTypeConfiguration<WaybillStatus>
    {
        public void Configure(EntityTypeBuilder<WaybillStatus> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(x => x.WaybillStatusHistory)
               .WithOne(x => x.Status)
               .HasForeignKey(x => x.StatusId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                 new WaybillStatus
                 {
                     Id = 1,
                     Title = "ارتباط با فرستنده",
                     TitleEn = "Communication with the sender",
                     Description = "در حال تماس و هماهنگی اولیه با فرستنده مرسوله."
                 },
                 new WaybillStatus
                 {
                     Id = 2,
                     Title = "دريافت مرسوله",
                     TitleEn = "Received shipment",
                     Description = "بسته از فرستنده تحویل گرفته شد و فرآیند ارسال آغاز گردید."
                 },
                 new WaybillStatus
                 {
                     Id = 3,
                     Title = "ورود مرسوله به هاب مبدا",
                     TitleEn = "Shipment entered the origin hub",
                     Description = "مرسوله وارد مرکز پردازش مبدا شد و در حال بررسی و ثبت است."
                 },
                 new WaybillStatus
                 {
                     Id = 4,
                     Title = "خروج از هاب به فرودگاه",
                     TitleEn = "Departed from the hub to the airport",
                     Description = "مرسوله از مرکز پردازش مبدا خارج و به سمت فرودگاه ارسال شد."
                 },
                 new WaybillStatus
                 {
                     Id = 5,
                     Title = "خروج از فرودگاه",
                     TitleEn = "Departed from the airport",
                     Description = "مرسوله کشور مبدا را ترک کرد و در مسیر پرواز قرار گرفت."
                 },
                 new WaybillStatus
                 {
                     Id = 6,
                     Title = "ورود به فرودگاه مقصد",
                     TitleEn = "Arrived at the destination airport",
                     Description = "مرسوله وارد فرودگاه کشور مقصد شد."
                 },
                 new WaybillStatus
                 {
                     Id = 7,
                     Title = "در حال ارزیابی گمرک",
                     TitleEn = "Under customs assessment",
                     Description = "مرسوله در حال بررسی و ارزیابی توسط کارشناسان گمرک مقصد است."
                 },
                 new WaybillStatus
                 {
                     Id = 8,
                     Title = "خروج از گمرک",
                     TitleEn = "Departed from customs",
                     Description = "مرسوله از گمرک مقصد ترخیص شد."
                 },
                 new WaybillStatus
                 {
                     Id = 9,
                     Title = "ورود به هاب مقصد",
                     TitleEn = "Arrived at the destination hub",
                     Description = "مرسوله وارد مرکز پردازش مقصد شد و آماده ارسال نهایی است."
                 },
                 new WaybillStatus
                 {
                     Id = 10,
                     Title = "در حال تحويل دادن",
                     TitleEn = "Delivering",
                     Description = "مرسوله توسط سفیر در حال تحویل به گیرنده است."
                 },
                 new WaybillStatus
                 {
                     Id = 11,
                     Title = "تحويل داده شد",
                     TitleEn = "Delivered",
                     Description = "مرسوله با موفقیت به گیرنده نهایی تحویل داده شد."
                 }
            );


          
        }
    }
}
