using System.ComponentModel.DataAnnotations;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Representative
{
    public class RepJobRequest
    {
        [Key]
        public int Id { get; set; } // شناسه منحصربه‌فرد ردیف

        [Display(Name = "عنوان شغل درخواستی")]
        public string JobTitle { get; set; } // عنوان شغل درخواستی

        [Display(Name = "کد درخواست")]
        public int RequestCode { get; set; } // کد درخواست

        [Display(Name = "شماره ردیف")]
        public int RowNumber { get; set; } // شماره ردیف
    }
}
