using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class InternationalOrderMapp : IEntityTypeConfiguration<InternationalOrder>
    {
        public void Configure(EntityTypeBuilder<InternationalOrder> builder)
        {
            builder.HasKey(o => o.Id);
            // وضعیت سفارش (یک به چند)
            builder.HasOne(o => o.OrderStatus)
                   .WithMany(s => s.InternationalOrders)
                   .HasForeignKey(o => o.OrderStatusId)
                 .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
