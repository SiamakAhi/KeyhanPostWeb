using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepAgencyType
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "عنوان نمایندگی")]
        public string AgencyTitle { get; set; } // عنوان نمایندگی

        [Display(Name = "کد نمایندگی")]
        public int AgencyCode { get; set; } // کد نمایندگی

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز نمایندگی

        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
