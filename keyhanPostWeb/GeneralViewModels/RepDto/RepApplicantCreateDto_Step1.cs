using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class RepApplicantCreateDto_Step1 : IValidatableObject
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime? RequestDate { get; set; }

        [Required(ErrorMessage = "نام متقاضی الزامی است")]
        [Display(Name = "نام متقاضی")]
        public string ApplicantName { get; set; }

        //[Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "شماره موبایل الزامی است")]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل نامعتبر است")]
        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "آدرس ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل نامعتبر است")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نوع شخصیت الزامی است")]
        [Display(Name = "نوع شخصیت")]
        public int EntityTypeId { get; set; } // نوع شخصیت

        [Required(ErrorMessage = "شناسه ملی الزامی است")]
        [Display(Name = "شناسه ملی")]
        public string NationalId { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "نحوه آشنایی یا کیهان پست")]
        public int IntroDuctionId { get; set; }
        public short currentStep { get; set; }

        [Display(Name = "کد پیگیری")]
        public string? TrackingCode { get; set; }

        [Display(Name = "میزان تحصیلات")]
        public int? EducationDegreeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EntityTypeId == 1 && (NationalId == null || NationalId.Length != 10))
            {
                yield return new ValidationResult("شناسه ملی باید 10 رقمی باشد.", new[] { nameof(NationalId) });
            }
            else if (EntityTypeId == 2 && (NationalId == null || NationalId.Length != 11))
            {
                yield return new ValidationResult("شناسه ملی باید 11 رقمی باشد.", new[] { nameof(NationalId) });
            }
        }
    }
}
