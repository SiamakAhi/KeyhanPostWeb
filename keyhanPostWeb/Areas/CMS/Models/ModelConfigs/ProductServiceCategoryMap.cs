using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class ProductServiceCategoryMap :IEntityTypeConfiguration<ProductServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ProductServiceCategory> builder)
        {
            builder.HasKey(k => k.Id);

        }
    }
}
