
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepDocumentTypeMapp : IEntityTypeConfiguration<RepDocumentType>
    {
        public void Configure(EntityTypeBuilder<RepDocumentType> builder)
        {
            builder.HasData(
                new RepDocumentType { Id = 1, DocumentTitle = "کارت ملی", UploadScore = 5, DocumentCode = 6000 },
                new RepDocumentType { Id = 2, DocumentTitle = "شناسنامه", UploadScore = 5, DocumentCode = 6001 },
                new RepDocumentType { Id = 3, DocumentTitle = "عکس", UploadScore = 5, DocumentCode = 6002 },
                new RepDocumentType { Id = 4, DocumentTitle = "گواهینامه", UploadScore = 5, DocumentCode = 6003 },
                new RepDocumentType { Id = 5, DocumentTitle = "پایان خدمت", UploadScore = 5, DocumentCode = 6004 },
                new RepDocumentType { Id = 6, DocumentTitle = "بیمه نامه", UploadScore = 5, DocumentCode = 6005 },
                new RepDocumentType { Id = 7, DocumentTitle = "مدرک تحصیلی", UploadScore = 5, DocumentCode = 6006 },
                new RepDocumentType { Id = 8, DocumentTitle = "گواهی امضاء", UploadScore = 5, DocumentCode = 6007 },
                new RepDocumentType { Id = 9, DocumentTitle = "گواهی سوء پیشینه", UploadScore = 5, DocumentCode = 6008 },
                new RepDocumentType { Id = 10, DocumentTitle = "گواهی عدم اعتیاد", UploadScore = 5, DocumentCode = 6009 },
                new RepDocumentType { Id = 11, DocumentTitle = "تعهدنامه عدم دریافت کالای قاچاق", UploadScore = 5, DocumentCode = 6010 },
                new RepDocumentType { Id = 12, DocumentTitle = "کپی سند یا اجاره نامه محل سکونت به همراه کدپستی", UploadScore = 5, DocumentCode = 6011 },
                new RepDocumentType { Id = 13, DocumentTitle = "کپی سند یا اجاره نامه محل مورد نظر جهت نمایندگی به همراه کدپستی", UploadScore = 5, DocumentCode = 6012 },
                new RepDocumentType { Id = 14, DocumentTitle = "فرم پیش ثبت نام سامانه ثنا", UploadScore = 5, DocumentCode = 6013 }
            );
        }
    }
}
