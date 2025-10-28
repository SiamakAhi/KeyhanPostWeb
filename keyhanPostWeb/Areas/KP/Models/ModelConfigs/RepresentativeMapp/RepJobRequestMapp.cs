
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepJobRequestMapp : IEntityTypeConfiguration<RepJobRequest>
    {
        public void Configure(EntityTypeBuilder<RepJobRequest> builder)
        {
            builder.HasData(
                    new RepJobRequest { Id = 1, JobTitle = "درخواست ایجاد نمایندگی", RequestCode = 2001, RowNumber = 1 },
                    new RepJobRequest { Id = 2, JobTitle = "درخواست ایجاد شعبه", RequestCode = 2002, RowNumber = 2 },
                    new RepJobRequest { Id = 3, JobTitle = "درخواست به عنوان همکار پیک موتوری", RequestCode = 2003, RowNumber = 3 },
                    new RepJobRequest { Id = 4, JobTitle = "درخواست به عنوان وانت بار به صورت سیار و ثابت", RequestCode = 2004, RowNumber = 4 },
                    new RepJobRequest { Id = 5, JobTitle = "درخواست به عنوان همکاری با کامیون", RequestCode = 2005, RowNumber = 5 },
                    new RepJobRequest { Id = 6, JobTitle = "درخواست همکاری در واحد تجزیه مبادلات", RequestCode = 2006, RowNumber = 6 },
                    new RepJobRequest { Id = 7, JobTitle = "درخواست همکاری نیروی بسته بند و ثبت سامانه", RequestCode = 2006, RowNumber = 7 }
                );
        }
    }
}