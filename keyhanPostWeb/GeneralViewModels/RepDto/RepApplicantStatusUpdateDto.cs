using System;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.GeneralViewModels.RepDto
{
    public class RepApplicantStatusUpdateDto
    {
        [Required(ErrorMessage = "شناسه متقاضی الزامی است")]
        [Display(Name = "شناسه")]
        public Guid ApplicantId { get; set; }

        [Required(ErrorMessage = "وضعیت جدید الزامی است")]
        [Display(Name = "وضعیت جدید")]
        public int NewStatusId { get; set; } // وضعیت جدید درخواست

        [Display(Name = "یادداشت ارزیابی")]
        public string EvaluationNote { get; set; } // یادداشت ارزیابی توسط مدیر
    }
}
