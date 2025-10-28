
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepEntityTypeMapp : IEntityTypeConfiguration<RepEntityType>
    {
        public void Configure(EntityTypeBuilder<RepEntityType> builder)
        {
            builder.HasData(
                new RepEntityType { Id = 1, EntityTitle = "حقیقی", EntityCode = 3001, Score = 50 },
                new RepEntityType { Id = 2, EntityTitle = "حقوقی", EntityCode = 3002, Score = 20 }
            );
        }
    }
}
