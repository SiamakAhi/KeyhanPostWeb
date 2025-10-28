using System;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.RepDto;
    public class RepApplicantCreateDto_Step2
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "انتخاب همکاری الزامی است")]
        [Display(Name = "نوع همکاری")]
        public int JobRequestId { get; set; }

        [Required(ErrorMessage = "انتخاب شهر الزامی است")]
        [Display(Name = "شهر محل فعالیت")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "نوع نمایندگی الزامی است")]
        [Display(Name = "نوع نمایندگی")]
        public int AgencyTypeId { get; set; } // نوع نمایندگی

        [Required(ErrorMessage = "وضعیت سابقه را انتخاب کنید")]
        [Display(Name = "سابقه فعالیت")]
        public int ExperienceId { get; set; } // سابقه فعالیت (nullable)

        [Required(ErrorMessage = "وضعیت وسیله نقلیه را انتخاب کنید")]
        [Display(Name = "وضعیت وسیله نقلیه")]
        public int? VehicleAvailabilityId { get; set; } // وضعیت وسیله نقلیه (nullable)

        [Display(Name = "نوع وسیله نقلیه")]
        public int? VehicleTypeId { get; set; } // وضعیت وسیله نقلیه (nullable)

        [Display(Name = "وضعیت ملک")]
        public int? PropertyTypeId { get; set; } // نوع ملک (nullable)

        [Display(Name = "توضیحات اضافه")]
        public string? AdditionalDesc { get; set; }

        [Display(Name = "آدرس محل فعالیت")]
        public string? BranchAddress { get; set; }

    }

