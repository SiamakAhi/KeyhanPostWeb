using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class CRMEmailAddressMap : IEntityTypeConfiguration<CRMEmailAddress>
    {
        public void Configure(EntityTypeBuilder<CRMEmailAddress> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasData(
                new CRMEmailAddress { Id = 1, Name = "پیگیری مرسولات", EmailAddress = "crm@keyhanpost.ir" },
                new CRMEmailAddress { Id = 2, Name = "استعلام هزینه پست داخلی", EmailAddress = "marketing@keyhanpost.ir" },
                new CRMEmailAddress { Id = 3, Name = "استعلام هزینه پست خارجی", EmailAddress = "marketing@keyhanpost.ir" },
                new CRMEmailAddress { Id = 4, Name = "انتقاد و پیشنهاد", EmailAddress = "ceo@keyhanpost.ir" },
                new CRMEmailAddress { Id = 5, Name = "امور شعب و نمایندگی", EmailAddress = "crm@keyhanpost.ir" },
                new CRMEmailAddress { Id = 6, Name = "سایر", EmailAddress = "info@keyhanpost.ir" }
                );
        }
    }
}
