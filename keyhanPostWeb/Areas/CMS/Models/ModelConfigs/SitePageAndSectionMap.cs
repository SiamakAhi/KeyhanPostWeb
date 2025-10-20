using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class SitePageAndSectionMap :IEntityTypeConfiguration<SitePageAndSection>
    {
        public void Configure(EntityTypeBuilder<SitePageAndSection> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasData(
                new SitePageAndSection { Id=1,SectionCode=1,SectionUrl="Home/Index",SerctionName="صحفه اول - معرفی"},
                new SitePageAndSection { Id=2,SectionCode=2,SectionUrl="Home/Index",SerctionName="صحفه اول - اهداف"},
                new SitePageAndSection { Id=3,SectionCode=3,SectionUrl="Home/Index",SerctionName="صحفه اول - آمارها"},
                new SitePageAndSection { Id=4,SectionCode=4,SectionUrl="Home/Index",SerctionName="صحفه اول - فرآیندهای کسب و کار"}
                );
        }
    }
}
