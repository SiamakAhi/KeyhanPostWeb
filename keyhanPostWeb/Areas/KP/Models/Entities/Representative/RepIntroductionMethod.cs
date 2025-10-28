using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepIntroductionMethod
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<RepApplicant> RepApplications { get; set; }
    }
}
