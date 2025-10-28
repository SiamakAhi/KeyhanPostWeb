using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class OrderMapp : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            // وضعیت سفارش (یک به چند)
            builder.HasOne(o => o.OrderStatus)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.OrderStatusId)
                 .OnDelete(DeleteBehavior.NoAction);


        }
    }

}
