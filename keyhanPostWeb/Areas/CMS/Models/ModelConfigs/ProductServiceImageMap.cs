using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class ProductServiceImageMap : IEntityTypeConfiguration<ProductServiceImage>
    {
        public void Configure(EntityTypeBuilder<ProductServiceImage> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(n => n.ProductService)
                .WithMany(m => m.ProductServiceImages)
                .HasForeignKey(f => f.ProductID);

        }
    }
}