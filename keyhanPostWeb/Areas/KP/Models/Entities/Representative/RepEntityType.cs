using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepEntityType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان شخصیت")]
        public string EntityTitle { get; set; } // عنوان شخصیت

        [Display(Name = "کد شخصیت")]
        public int EntityCode { get; set; } // کد شخصیت

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز شخصیت
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
