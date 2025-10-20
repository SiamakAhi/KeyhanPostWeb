using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.PersonViewModels
{
    public class VmPerson
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "نام ")]
        public string FName { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "نام خانوادگی ")]
        public string LastName { get; set; }

        [Display(Name = "نام پدر ")]
        public string FatherName { get; set; }

        [Display(Name = "کد ملی ")]
        public string NotionalityCode { get; set; }

        [Required(ErrorMessage = "نوشتن {0} الزامی است")]
        [Display(Name = "شماره همراه")]
        public string Mobile { get; set; }

        [Display(Name = "جنسیت ")]
        public byte Gender { get; set; }

        [Display(Name = "شماره نظام پزشکی ")]
        public string IdentityCode { get; set; }

        [Display(Name = "ماهیت")]
        public string PersonType { get; set; }

        [Display(Name = "کارمند")]
        public bool IsEmployee { get; set; }

        [Display(Name = "بیمار")]
        public bool IsPatient { get; set; }

        [Display(Name = "مراکز معرفی بیمار")]
        public bool IsMoaref { get; set; }

        [Display(Name = "بازاریاب")]
        public bool IsBazarYab { get; set; }
    }
}
