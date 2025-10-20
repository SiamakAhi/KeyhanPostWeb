using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class ProductServiceMap : IEntityTypeConfiguration<ProductService>
    {
        public void Configure(EntityTypeBuilder<ProductService> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(n => n.ProductCategory)
                .WithMany(m => m.ProductServices)
                .HasForeignKey(f => f.ProductCategoryID);

        }
    }
}
