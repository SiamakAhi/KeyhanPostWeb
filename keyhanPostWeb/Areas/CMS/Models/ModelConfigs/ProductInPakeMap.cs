using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using keyhanPostWeb.Areas.CMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuineWebApp.Areas.CMS.Models.ModelConfigs
{
    public class ProductInPakeMap :IEntityTypeConfiguration<ProductInPakge>
    {
        public void Configure(EntityTypeBuilder<ProductInPakge> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.Product)
                .WithMany(n => n.ProductInPakges)
                .HasForeignKey(f => f.ProductId);

            builder.HasOne(n => n.Pakage)
                .WithMany(n => n.ProductInPakges)
                .HasForeignKey(f => f.PakageId);
        }
    }
}
