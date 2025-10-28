
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepRequestStatusMapp : IEntityTypeConfiguration<RepRequestStatus>
    {
        public void Configure(EntityTypeBuilder<RepRequestStatus> builder)
        {
            builder.HasData(
                new RepRequestStatus { Id = 20, StatusTitle = "در حال تکمیل درخواست", StatusCode = 2001 },
                new RepRequestStatus { Id = 10, StatusTitle = "در صف بررسی", StatusCode = 1001 },
                new RepRequestStatus { Id = 11, StatusTitle = "درحال بررسی و امکانسنجی", StatusCode = 1002 },
                new RepRequestStatus { Id = 12, StatusTitle = "رد درخواست", StatusCode = 1003 },
                new RepRequestStatus { Id = 13, StatusTitle = "موافقت اولیه درخواست", StatusCode = 1004 },
                new RepRequestStatus { Id = 14, StatusTitle = "نقص مدارک نیاز به بارگذاری مجدد دارد.", StatusCode = 1005 }
            );
        }
    }
}
