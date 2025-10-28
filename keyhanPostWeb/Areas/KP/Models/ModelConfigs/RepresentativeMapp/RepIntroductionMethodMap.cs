
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepIntroductionMethodMap : IEntityTypeConfiguration<RepIntroductionMethod>
    {
        public void Configure(EntityTypeBuilder<RepIntroductionMethod> builder)
        {


            builder.HasData(
                new RepIntroductionMethod { Id = 1, Code = 3001, Title = "وب سایت شرکت کیهان پست" },
                new RepIntroductionMethod { Id = 2, Code = 3002, Title = "آگهی دیوار" },
                new RepIntroductionMethod { Id = 3, Code = 3003, Title = "وب سایت جابینجا" },
                new RepIntroductionMethod { Id = 4, Code = 3004, Title = "وب سایت جابویژن" },
                new RepIntroductionMethod { Id = 5, Code = 3005, Title = "وب سایت ایران تلنت" },
                new RepIntroductionMethod { Id = 6, Code = 3006, Title = "فضای مجازی" },
                new RepIntroductionMethod { Id = 7, Code = 3007, Title = "روزنامه" },
                new RepIntroductionMethod { Id = 8, Code = 3008, Title = "صداوسیما" },
                new RepIntroductionMethod { Id = 9, Code = 3009, Title = "دوستان و آشنایان" },
                new RepIntroductionMethod { Id = 10, Code = 3010, Title = "سایر" }
            );
        }
    }
}
