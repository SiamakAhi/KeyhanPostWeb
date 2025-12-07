using System.ComponentModel.DataAnnotations.Schema;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class WaybillStatusHistory
    {
        public int Id { get; set; }

        public int WaybillId { get; set; }
        [ForeignKey(nameof(WaybillId))]
        public InternationalWaybill Waybill { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public WaybillStatus Status { get; set; }

        public DateTime ChangedAt { get; set; } 

      
    }
}
