using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepVehicleType
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "عنوان وسیله نقلیه")]
        public string VehicleTitle { get; set; } // عنوان وسیله نقلیه

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز وسیله نقلیه

        [Display(Name = "کد وسیله نقلیه")]
        public int VehicleCode { get; set; } // کد وسیله نقلیه
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
