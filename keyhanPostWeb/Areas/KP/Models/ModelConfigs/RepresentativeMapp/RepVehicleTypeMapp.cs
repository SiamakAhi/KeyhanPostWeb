
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepVehicleTypeMapp : IEntityTypeConfiguration<RepVehicleType>
    {
        public void Configure(EntityTypeBuilder<RepVehicleType> builder)
        {
            builder.HasData(
                new RepVehicleType { Id = 1, VehicleTitle = "سواری", Score = 5, VehicleCode = 7000 },
                new RepVehicleType { Id = 2, VehicleTitle = "موتور سیکلت", Score = 10, VehicleCode = 7001 },
                new RepVehicleType { Id = 3, VehicleTitle = "وانت", Score = 20, VehicleCode = 7002 },
                new RepVehicleType { Id = 4, VehicleTitle = "نیسان", Score = 20, VehicleCode = 7003 },
                new RepVehicleType { Id = 5, VehicleTitle = "کامیون", Score = 30, VehicleCode = 7004 },
                new RepVehicleType { Id = 6, VehicleTitle = "تریلی", Score = 50, VehicleCode = 7005 }
            );
        }
    }
}
