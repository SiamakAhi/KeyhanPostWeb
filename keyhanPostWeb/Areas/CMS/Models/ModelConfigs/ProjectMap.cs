using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using keyhanPostWeb.Areas.CMS.Models.Entities;

namespace keyhanPostWeb.Areas.CMS.Models.ModelConfigs
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(n => n.projectID);


        }
    }
}
