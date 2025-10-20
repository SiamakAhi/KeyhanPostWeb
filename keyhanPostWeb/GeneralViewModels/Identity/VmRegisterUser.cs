using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Identity
{
    public class VmRegisterUser
    {
        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "نام ")]
        public string FName { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string LName { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "نام کاربری")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "انتخاب حداقل یک نقش الزامی است")]
        [Display(Name = "نقش ها")]
        public string[] Roles { get; set; }

        [Display(Name = "شناسه رخساره")]
        public int RokPersonID { get; set; }
    }
}
