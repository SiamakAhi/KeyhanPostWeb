using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class InternationalWaybillMapp : IEntityTypeConfiguration<InternationalWaybill>
    {
        public void Configure(EntityTypeBuilder<InternationalWaybill> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(x => x.WaybillStatusHistory)
               .WithOne(x => x.Waybill)
               .HasForeignKey(x => x.WaybillId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
