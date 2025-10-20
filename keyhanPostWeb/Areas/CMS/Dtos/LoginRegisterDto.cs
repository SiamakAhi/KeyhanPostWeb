using keyhanPostWeb.GeneralViewModels.Identity;

namespace keyhanPostWeb.Areas.Club.Dtos
{
    public class LoginRegisterDto
    {
        public SignInViewModel? login { get; set; }
        public VmSignUp? register { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
