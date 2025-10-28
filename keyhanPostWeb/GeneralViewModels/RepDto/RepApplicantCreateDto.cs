using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class RepApplicantCreateDto : IValidatableObject
    {

        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "نام متقاضی الزامی است")]
        [Display(Name = "نام متقاضی")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
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

        [Required(ErrorMessage = "شناسه ملی الزامی است")]
        [Display(Name = "شناسه ملی")]
        public string NationalId { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Required(ErrorMessage = "نوع شخصیت الزامی است")]
        [Display(Name = "نوع شخصیت")]
        public int EntityTypeId { get; set; } // نوع شخصیت

        public int? JobRequestId { get; set; }

        [Required(ErrorMessage = "نوع نمایندگی الزامی است")]
        [Display(Name = "نوع نمایندگی")]
        public int AgencyTypeId { get; set; } // نوع نمایندگی

        [Display(Name = "سابقه فعالیت")]
        public int? ExperienceId { get; set; } // سابقه فعالیت (nullable)

        [Display(Name = "وضعیت وسیله نقلیه")]
        public int? VehicleAvailabilityId { get; set; } // وضعیت وسیله نقلیه (nullable)

        [Display(Name = "نوع ملک")]
        public int? PropertyTypeId { get; set; } // نوع ملک (nullable)

        [Display(Name = "مدارک مورد نیاز")]
        public List<int> DocumentTypeIds { get; set; } // لیست مدارک

        /// <summary>
        /// متد اعتبارسنجی شناسه ملی بر اساس نوع شخصیت
        /// </summary>
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
