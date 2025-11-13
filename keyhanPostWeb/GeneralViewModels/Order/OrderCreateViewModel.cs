using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.Order
{
    public class OrderCreateViewModel
    {
        
        [Required(ErrorMessage = "لطفاً نوع بسته را انتخاب کنید.")]
        [Display(Name = "نوع بسته")]
        public short PackageTypeId { get; set; }

     
        [Required(ErrorMessage = "لطفاً شهر مبدا را انتخاب کنید.")]
        [Display(Name = "شهر مبدا")]
        public int? OriginCityId { get; set; }

        [Required(ErrorMessage = "لطفاً کشور مبدا را انتخاب کنید.")]
        [Display(Name = "کشور مبدا")]
        public string? OriginCountryName { get; set; }

        [Required(ErrorMessage = "لطفاً شهر مقصد را انتخاب کنید.")]
        [Display(Name = "شهر مقصد")]
        public int? DestinationCityId { get; set; }

        [Required(ErrorMessage = "لطفاً کشور مقصد را انتخاب کنید.")]
        [Display(Name = "کشور مقصد")]
        public string? DestinationCountryName { get; set; }


        public IEnumerable<SelectListItem>? Cities { get; set; }
        public IEnumerable<SelectListItem>? contries { get; set; }


        [Range(1, 500, ErrorMessage = "طول باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
        [Display(Name = "طول (cm)")]
        public double Length { get; set; }

        [Range(1, 500, ErrorMessage = "عرض باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
        [Display(Name = "عرض (cm)")]
        public double Width { get; set; }

        [Range(1, 500, ErrorMessage = "ارتفاع باید بین ۱ تا ۵۰۰ سانتی‌متر باشد.")]
        [Display(Name = "ارتفاع (cm)")]
        public double Height { get; set; }

        [Range(0.1, 200, ErrorMessage = "وزن باید بین ۰.۱ تا ۲۰۰ کیلوگرم باشد.")]
        [Display(Name = "وزن (kg)")]
        public double ActualWeight { get; set; }

       
        [Required(ErrorMessage = "لطفاً نام فرستنده را وارد کنید.")]
        [StringLength(100, ErrorMessage = "نام فرستنده نمی‌تواند بیش از ۱۰۰ کاراکتر باشد.")]
        [Display(Name = "نام فرستنده")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "لطفاً تلفن فرستنده را وارد کنید.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تلفن فرستنده معتبر نیست.")]
        [Display(Name = "تلفن فرستنده")]
        public string SenderPhone { get; set; }

        [Required(ErrorMessage = "لطفاً کد ملی فرستنده را وارد کنید.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی فرستنده باید ۱۰ رقم باشد.")]
        [Display(Name = "کد ملی فرستنده")]
        public string SenderNationalId { get; set; }

        [Required(ErrorMessage = "لطفاً آدرس فرستنده را وارد کنید.")]
        [StringLength(500, ErrorMessage = "آدرس فرستنده نمی‌تواند بیش از ۵۰۰ کاراکتر باشد.")]
        [Display(Name = "آدرس فرستنده")]
        public string SenderAddress { get; set; }

    
        [Required(ErrorMessage = "لطفاً نام گیرنده را وارد کنید.")]
        [StringLength(100, ErrorMessage = "نام گیرنده نمی‌تواند بیش از ۱۰۰ کاراکتر باشد.")]
        [Display(Name = "نام گیرنده")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "لطفاً تلفن گیرنده را وارد کنید.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تلفن گیرنده معتبر نیست.")]
        [Display(Name = "تلفن گیرنده")]
        public string ReceiverPhone { get; set; }

        [Required(ErrorMessage = "لطفاً کد ملی گیرنده را وارد کنید.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی گیرنده باید ۱۰ رقم باشد.")]
        [Display(Name = "کد ملی گیرنده")]
        public string ReceiverNationalId { get; set; }

        [Required(ErrorMessage = "لطفاً آدرس گیرنده را وارد کنید.")]
        [StringLength(500, ErrorMessage = "آدرس گیرنده نمی‌تواند بیش از ۵۰۰ کاراکتر باشد.")]
        [Display(Name = "آدرس گیرنده")]
        public string ReceiverAddress { get; set; }


    }
}
