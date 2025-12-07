using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class OrderStatusMapp : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(s => s.Id);

            // --- Seed Data ---
            builder.HasData(
                new OrderStatus { Id = 1, Title = "در حال تکمیل", Description = "درخواست کننده در حال ثبت اطلاعات است." },
                new OrderStatus { Id = 2, Title = "تکمیل شده", Description = "اطلاعات سفارش تکمیل است." },
                new OrderStatus { Id = 3, Title = "بررسی شده", Description = "سفارش بررسی شده." },
                new OrderStatus { Id = 4, Title = "لغو شده", Description = "سفارش لغو شده است." }
            );

        }
    }

}
