using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Identity
{
    public class RolesViewModel
    {
        public string Id { get; set; }

        [Display(Name = "نقش")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "کاربران")]
        public int UsersCount { get; set; }
    }
}
