using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class SectionsContentMap :IEntityTypeConfiguration<SectionsContent>
    {
        public void Configure(EntityTypeBuilder<SectionsContent> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(n => n.PageOrSection)
                .WithMany(n => n.SectionsContents)
                .HasForeignKey(f => f.SectionID);
        }
    }
}
