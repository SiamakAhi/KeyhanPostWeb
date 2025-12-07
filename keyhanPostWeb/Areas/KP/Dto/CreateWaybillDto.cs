using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class CreateWaybillDto
    {
       

        [Display(Name = "تعداد بسته")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} باید بزرگتر از صفر باشد.")]
        public int PackageCount { get; set; }

        [Display(Name = "وزن بسته (کیلوگرم)")]
        [Range(0.1, double.MaxValue, ErrorMessage = "{0} باید بزرگتر از صفر باشد.")]
        public double PackageWeight { get; set; }

        [Display(Name = "کشور مبدا")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string OriginCountryName { get; set; }

        [Display(Name = "کشور مقصد")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string DestinationCountryName { get; set; }

        [Display(Name = "نام فرستنده")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string SenderName { get; set; }

        [Display(Name = "نام گیرنده")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string ReceiverName { get; set; }

        [Display(Name = "وضعیت")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفاً {0} را انتخاب کنید.")]
        public int StatusId { get; set; }   // وضعیت اولیه

        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ را انتخاب کنید")]
        [DisplayName("تاریخ")]
        public string? StrCreateAt { get; set; }

    }
}
