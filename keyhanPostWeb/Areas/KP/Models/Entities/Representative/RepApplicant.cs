namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// نماینده‌ای از متقاضیان دریافت نمایندگی که شامل اطلاعات اصلی متقاضی و ارتباطات با جداول پایه است.
    /// </summary>
    public class RepApplicant
    {
        /// <summary>
        /// شناسه منحصربه‌فرد متقاضی (GUID).
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// نام متقاضی، فیلدی اجباری برای ثبت‌نام متقاضی.
        /// </summary>
        [Required]
        [Display(Name = "نام متقاضی")]
        public string ApplicantName { get; set; }

        /// <summary>
        /// نام کاربری متقاضی، فیلدی اجباری برای نمایش اطلاعات در پنل کاربری.
        /// </summary>
        [Required]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        /// <summary>
        /// شماره موبایل متقاضی، با اعتبارسنجی ۱۱ رقمی برای جلوگیری از ورود داده نامعتبر.
        /// </summary>
        [Required]
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل نامعتبر است")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// آدرس ایمیل متقاضی، با اعتبارسنجی ایمیل برای اطمینان از صحت ایمیل.
        /// </summary>
        [Display(Name = "آدرس ایمیل")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل نامعتبر است")]
        public string Email { get; set; }

        /// <summary>
        /// شناسه ملی متقاضی. این فیلد برای اشخاص حقیقی باید ۱۰ رقمی و برای اشخاص حقوقی ۱۱ رقمی باشد.
        /// </summary>
        [Required]
        [Display(Name = "شناسه ملی")]
        [CustomValidation(typeof(RepApplicant), nameof(ValidateNationalId))]
        public string NationalId { get; set; }

        /// <summary>
        /// آدرس متقاضی برای ارسال مدارک و ارتباطات.
        /// </summary>
        [Display(Name = "آدرس")]
        public string? Address { get; set; }

        /// <summary>
        /// کد پیگیری برای پیگیری وضعیت درخواست متقاضی.
        /// </summary>
        [Display(Name = "کد پیگیری")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// امتیاز کل متقاضی بر اساس اطلاعات وارد شده و ارتباط با جداول پایه.
        /// </summary>
        [Display(Name = "امتیاز کل")]
        public int? TotalScore { get; set; }

        /// <summary>
        /// تاریخ ثبت درخواست متقاضی.
        /// </summary>
        [Display(Name = "تاریخ درخواست")]
        public DateTime? RequestDate { get; set; }

        // ارتباطات با جداول پایه

        /// <summary>
        /// شناسه نوع شخصیت متقاضی (حقیقی یا حقوقی).
        /// </summary>
        public int? EntityTypeId { get; set; }
        public virtual RepEntityType? EntityType { get; set; }

        public int? EducationId { get; set; }
        public virtual RepEducationDegree EducationDegree { get; set; }
        /// <summary>
        /// شناسه نوع نمایندگی مورد درخواست متقاضی.
        /// </summary>
        public int? AgencyTypeId { get; set; }
        public virtual RepAgencyType? AgencyType { get; set; }

        /// <summary>
        /// شناسه وضعیت درخواست متقاضی.
        /// </summary>
        public int? RequestStatusId { get; set; }
        public virtual RepRequestStatus? RequestStatus { get; set; }

        public int? JobRequestId { get; set; }
        public virtual RepJobRequest? JobRequest { get; set; }

        /// <summary>
        /// شناسه سابقه فعالیت متقاضی.
        /// </summary>
        public int? ExperienceId { get; set; }
        public virtual RepExperience? Experience { get; set; }

        /// <summary>
        /// شناسه وضعیت وسیله نقلیه متقاضی.
        /// </summary>
        public int? VehicleAvailabilityId { get; set; }
        public virtual RepVehicleAvailability? VehicleAvailability { get; set; }

        public int? VehicleTypeId { get; set; }
        public virtual RepVehicleType? VehicleType { get; set; }

        /// <summary>
        /// شناسه نوع ملک مورد استفاده متقاضی.
        /// </summary>
        public int? PropertyTypeId { get; set; }
        public virtual RepPropertyType? PropertyType { get; set; }


        public int? CityId { get; set; }
        public virtual RepCity? City { get; set; }
        public string? BranchAddress { get; set; }

        public int? IntroductionId { get; set; }
        public virtual RepIntroductionMethod Introduction { get; set; }


        [Display(Name = "چنانچه لازم می دانید توضیحاتی ارایه دهید که در فرم درخواست آورده نشده را در کادر زیر بنویسید")]
        public string? JobSeekerRemarks { get; set; }
        //یادداشت ارزیابی
        public string? EvaluationNote { get; set; }
        public bool Approved { get; set; }
        public short currentStep { get; set; }
        public virtual ICollection<RepUploadedDocument> RepUploadedDocuments { get; set; }
        /// <summary>
        /// متد اعتبارسنجی شناسه ملی بر اساس نوع شخصیت.
        /// </summary>
        public static ValidationResult ValidateNationalId(string nationalId, ValidationContext context)
        {
            var instance = context.ObjectInstance as RepApplicant;
            if (instance != null)
            {
                if (instance.EntityTypeId == 1 && (nationalId == null || nationalId.Length != 10))
                {
                    return new ValidationResult("شناسه ملی باید 10 رقمی باشد.");
                }
                if (instance.EntityTypeId == 2 && (nationalId == null || nationalId.Length != 11))
                {
                    return new ValidationResult("شناسه ملی باید 11 رقمی باشد.");
                }
            }
            return ValidationResult.Success;
        }
    }

}
