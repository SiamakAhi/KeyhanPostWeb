using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative;
    public class RepProvince
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد

        [Display(Name = "کد استان")]
        public int ProvinceCode { get; set; } // کد استان

        [Display(Name = "نام استان")]
        public string ProvinceName { get; set; } // نام استان

        public virtual ICollection<RepCity> Cities { get; set; }
    }

