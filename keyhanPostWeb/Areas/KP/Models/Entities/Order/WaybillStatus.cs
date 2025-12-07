using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class WaybillStatus
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }      // فارسی
        public string TitleEn { get; set; }    // انگلیسی

        // ارتباط با تاریخچه
        public virtual ICollection<WaybillStatusHistory> WaybillStatusHistory { get; set; }

    }
}
