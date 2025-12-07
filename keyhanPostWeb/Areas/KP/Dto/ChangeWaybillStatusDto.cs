using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class ChangeWaybillStatusDto
    {
        public int WaybillId { get; set; }

        [Required(ErrorMessage = "لطفاً وضعیت را انتخاب کنید")]
        [DisplayName("وضعیت جدید")]
        public int NewStatusId { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ ویرایش را انتخاب کنید")]
        [DisplayName("تاریخ")]
        public DateTime ChangedAt { get; set; }

        [Required(ErrorMessage = "لطفاً تاریخ ویرایش را انتخاب کنید")]
        [DisplayName("تاریخ")]
        public string StrChangedAt { get; set; }
    }
}
