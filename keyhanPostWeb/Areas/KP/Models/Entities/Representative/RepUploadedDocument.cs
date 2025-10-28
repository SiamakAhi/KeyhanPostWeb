using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepUploadedDocument
    {
        [Key]
        public Guid Id { get; set; } // شناسه منحصربه‌فرد برای هر مدرک آپلود شده (Guid)

        [Required]
        public Guid ApplicantId { get; set; } // شناسه متقاضی
        [ForeignKey("ApplicantId")]
        public RepApplicant Applicant { get; set; } // ارتباط با جدول متقاضیان

        [Display(Name = "عنوان مدرک")]
        public int DocumentTypeId { get; set; } // نوع مدرک
        [ForeignKey("DocumentTypeId")]
        public RepDocumentType DocumentType { get; set; } // ارتباط با جدول انواع مدارک

        [Display(Name = "مسیر فایل")]
        public string FilePath { get; set; } // مسیر ذخیره فایل مدرک

        [Display(Name = "تاریخ آپلود")]
        public DateTime UploadDate { get; set; } // تاریخ آپلود مدرک
    }

}
