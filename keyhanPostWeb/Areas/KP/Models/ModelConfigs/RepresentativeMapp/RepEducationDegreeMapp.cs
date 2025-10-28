
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepEducationDegreeMapp : IEntityTypeConfiguration<RepEducationDegree>
    {
        public void Configure(EntityTypeBuilder<RepEducationDegree> builder)
        {
            builder.HasData(
                new RepEducationDegree { Id = 1, DegreeTitle = "سیکل", Score = 5, DegreeCode = 5001 },
                new RepEducationDegree { Id = 2, DegreeTitle = "دیپلم", Score = 10, DegreeCode = 5002 },
                new RepEducationDegree { Id = 3, DegreeTitle = "فوق دیپلم", Score = 15, DegreeCode = 5003 },
                new RepEducationDegree { Id = 4, DegreeTitle = "لیسانس", Score = 20, DegreeCode = 5004 },
                new RepEducationDegree { Id = 5, DegreeTitle = "فوق لیسانس", Score = 25, DegreeCode = 5005 },
                new RepEducationDegree { Id = 6, DegreeTitle = "دکتری", Score = 30, DegreeCode = 5006 }
            );
        }
    }
}
