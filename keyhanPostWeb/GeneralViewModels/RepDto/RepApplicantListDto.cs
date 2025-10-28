using System;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class RepApplicantListDto
    {
        [Display(Name = "شناسه")]
        public Guid Id { get; set; }

        [Display(Name = "نام متقاضی")]
        public string ApplicantName { get; set; }

        [Display(Name = "کد پیگیری")]
        public string TrackingCode { get; set; }

        [Display(Name = "وضعیت درخواست")]
        public string RequestStatus { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime RequestDate { get; set; }
    }
}
