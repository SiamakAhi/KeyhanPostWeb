using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepRequestStatus
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "عنوان وضعیت")]
        public string StatusTitle { get; set; } // عنوان وضعیت

        [Display(Name = "کد وضعیت")]
        public int StatusCode { get; set; } // کد وضعیت
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
