
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepVehicleAvailabilityMapp : IEntityTypeConfiguration<RepVehicleAvailability>
    {
        public void Configure(EntityTypeBuilder<RepVehicleAvailability> builder)
        {
            builder.HasData(
                new RepVehicleAvailability { Id = 1, AvailabilityTitle = "دارم", AvailabilityCode = 9000, Score = 50 },
                new RepVehicleAvailability { Id = 2, AvailabilityTitle = "ندارم", AvailabilityCode = 9001, Score = 0 }
            );
        }
    }
}
