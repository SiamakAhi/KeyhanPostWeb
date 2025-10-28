
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepPropertyTypeMapp : IEntityTypeConfiguration<RepPropertyType>
    {
        public void Configure(EntityTypeBuilder<RepPropertyType> builder)
        {
            builder.HasData(
                new RepPropertyType { Id = 1, PropertyTitle = "استجاری", PropertyCode = 3001, Score = 10 },
                new RepPropertyType { Id = 2, PropertyTitle = "مالک", PropertyCode = 3002, Score = 50 }
            );
        }
    }
}
