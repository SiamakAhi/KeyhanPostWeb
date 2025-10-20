using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Identity
{
    public class SignInViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} خود را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} خود را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }=false;
    }
}
