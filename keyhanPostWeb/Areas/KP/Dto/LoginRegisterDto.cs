using keyhanPostWeb.GeneralViewModels.Identity;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class LoginRegisterDto
    {
        public SignInViewModel? Login { get; set; }
        public VmSignUp? Register { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
