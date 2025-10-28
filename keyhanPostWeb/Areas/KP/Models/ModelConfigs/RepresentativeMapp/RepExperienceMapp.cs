
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepExperienceMapp : IEntityTypeConfiguration<RepExperience>
    {
        public void Configure(EntityTypeBuilder<RepExperience> builder)
        {
            builder.HasData(
                new RepExperience { Id = 1, ExperienceTitle = "سابقه فعالیت دارم", ExperienceCode = 4000, Score = 50 },
                new RepExperience { Id = 2, ExperienceTitle = "سابقه فعالیت ندارم", ExperienceCode = 4001, Score = 0 }
            );
        }
    }
}
