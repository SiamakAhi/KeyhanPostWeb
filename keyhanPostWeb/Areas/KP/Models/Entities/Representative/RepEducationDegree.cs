using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepEducationDegree
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "عنوان مدرک تحصیلی")]
        public string DegreeTitle { get; set; } // عنوان مدرک تحصیلی

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز مدرک

        [Display(Name = "کد مدرک")]
        public int DegreeCode { get; set; } // کد مدرک
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
