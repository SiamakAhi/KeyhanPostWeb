using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Identity
{
    public class VmRole
    {
        [Display(Name = "نقش")]
        public string Id { get; set; }

        [Display(Name = "نقش")]
        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        public string Name { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }
    }
}
