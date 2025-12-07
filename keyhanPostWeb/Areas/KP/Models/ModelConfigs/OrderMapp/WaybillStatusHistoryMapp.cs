using keyhanPostWeb.Areas.KP.Models.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.OrderMapp
{
    public class WaybillStatusHistoryMapp : IEntityTypeConfiguration<WaybillStatusHistory>
    {
        public void Configure(EntityTypeBuilder<WaybillStatusHistory> builder)
        {
            builder.HasKey(s => s.Id);


        }
    }
}
