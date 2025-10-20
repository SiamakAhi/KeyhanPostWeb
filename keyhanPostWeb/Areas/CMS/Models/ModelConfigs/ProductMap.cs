using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class ProductMap :IEntityTypeConfiguration<Product>
    {
        public void Configure (EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.ProductID);
            builder.Property(p => p.ShortTitle).IsRequired();

            builder.HasOne(n => n.Category)
                .WithMany(n => n.Products)
                .HasForeignKey(f => f.CategoryID);
        }
    }
}
