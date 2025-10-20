using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Identity
{
    public class VmUpdateProfile
    {
        public string Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string userName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "نوشتن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        [MaxLength(200, ErrorMessage = "ایمیل نباید بیشتر از 200 کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "نوشتن شماره موبایل الزامی است")]
        // [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نیست (فرمت صحیح: 09123456789)")]
        public string Mobile { get; set; }

        [Display(Name = "شماره تلفن")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی خود را وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "تاریخ تولد")]

        public DateTime? BirthDate { get; set; }

        public DateTime RegisterDate { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "تاریخ تولد خود را بدرستی وارد کنید")]
        public string? StrBirthDate { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public string? Image { get; set; }

        [Display(Name = "تصویر پروفایل")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "جنسیت")]
        public Int16? Gender { get; set; }

        public int? PersonId { get; set; }
    }
}
