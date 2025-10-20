using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class PhotoGalleryMap : IEntityTypeConfiguration<PhotoGallery>
    {
        public void Configure(EntityTypeBuilder<PhotoGallery> builder)
        {
            builder.HasKey(k => k.photoID);
            builder.Property(p => p.FileName).IsRequired();
        }
    }
}
