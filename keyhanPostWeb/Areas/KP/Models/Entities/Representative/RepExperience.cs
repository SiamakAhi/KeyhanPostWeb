using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepExperience
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان سابقه فعالیت")]
        public string ExperienceTitle { get; set; } // عنوان سابقه فعالیت

        [Display(Name = "کد سابقه فعالیت")]
        public int ExperienceCode { get; set; } // کد سابقه فعالیت

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز سابقه فعالیت
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
