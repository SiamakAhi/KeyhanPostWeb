using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class BlogCommentMap : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.HasKey(k => k.ComID);

            builder.HasOne(n => n.Blog)
                .WithMany(n => n.BlogComments)
                .HasForeignKey(f => f.BlogID);

        }
    }
}
