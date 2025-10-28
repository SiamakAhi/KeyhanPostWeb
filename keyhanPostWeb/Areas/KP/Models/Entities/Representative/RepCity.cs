using System.Collections.Generic;
using keyhanPostWeb.Areas.KP.Models.Entities.Order;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepCity
    {
        [Key]
        public int Id { get; set; }

        public int ProvinceId { get; set; }
        public string CityName { get; set; }

        public virtual RepProvince Province { get; set; }

        // Navigation
        public virtual ICollection<RepApplicant> RepApplications { get; set; }
       
    }
}
