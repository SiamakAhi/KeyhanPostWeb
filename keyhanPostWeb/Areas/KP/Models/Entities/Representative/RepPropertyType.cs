using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepPropertyType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان ملک")]
        public string PropertyTitle { get; set; } // عنوان ملک

        [Display(Name = "کد ملک")]
        public int PropertyCode { get; set; } // کد ملک

        [Display(Name = "امتیاز")]
        public int Score { get; set; } // امتیاز ملک
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
