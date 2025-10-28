
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepAgencyTypeMapp : IEntityTypeConfiguration<RepAgencyType>
    {
        public void Configure(EntityTypeBuilder<RepAgencyType> builder)
        {
            builder.HasData(
                new RepAgencyType { Id = 1, AgencyTitle = "ثابت", AgencyCode = 5000, Score = 30 },
                new RepAgencyType { Id = 2, AgencyTitle = "سیار", AgencyCode = 5001, Score = 20 },
                new RepAgencyType { Id = 3, AgencyTitle = "ثابت و سیار", AgencyCode = 5002, Score = 50 }
            );
        }
    }
}
