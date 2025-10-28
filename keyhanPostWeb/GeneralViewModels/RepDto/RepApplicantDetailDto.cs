using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class RepApplicantDetailDto
    {
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }

        [Display(Name = "شماره پیگیری")]
        public string TrackingNumber { get; set; }

        [Display(Name = "نام متقاضی")]
        public string ApplicantName { get; set; }

        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }

        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Display(Name = "شناسه ملی")]
        public string NationalId { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }



        [Display(Name = "کد پیگیری")]
        public string TrackingCode { get; set; }

        [Display(Name = "میزان تحصیلات")]
        public string EducationDegree { get; set; }
        public int? EducationDegree_Score { get; set; }

        [Display(Name = "امتیاز کل")]
        public int? TotalScore { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "نوع شخصیت")]
        public string EntityType { get; set; }
        [Display(Name = "نحوه آشنایی با ما")]
        public string Introduction { get; set; }


        //............................................

        [Display(Name = "نوع نمایندگی")]
        public string AgencyType { get; set; }
        public int? AgencyType_Score { get; set; }

        [Display(Name = "وضعیت درخواست")]
        public string RequestStatus { get; set; }

        [Display(Name = "سابقه فعالیت")]
        public string Experience { get; set; }
        public int? Experience_Score { get; set; }

        [Display(Name = "وضعیت وسیله نقلیه")]
        public string VehicleAvailability { get; set; }
        public int? VehicleAvailability_Score { get; set; }

        [Display(Name = "نوع خودرو")]
        public string VehicleType { get; set; }
        public int? VehicleTypeId { get; set; }

        [Display(Name = "شهر محل فعالیت")]
        public string CityName { get; set; }   // استان - شهر
        public int? CityId { get; set; }
        [Display(Name = "آدرس محل نمایندگی")]
        public string BranchAddress { get; set; }

        [Display(Name = "وضعیت ماکیت ملک")]
        public string PropertyType { get; set; }
        public int? PropertyType_Score { get; set; }

        [Display(Name = "سایر توضیحات متقاضی")]
        public string OtherDesc { get; set; }

        public int CurrentStep { get; set; }

        [Display(Name = "مدارک آپلود شده")]
        public List<string> UploadedDocuments { get; set; } // لیستی از مدارک آپلود شده
    }
}
