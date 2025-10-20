using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class SectionListItemMap : IEntityTypeConfiguration<SectionsListItem>
    {
        public void Configure(EntityTypeBuilder<SectionsListItem> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(n => n.ForSection)
                .WithMany(n => n.ListItems)
                .HasForeignKey(f => f.SectionContentID);
        }
    }
}
