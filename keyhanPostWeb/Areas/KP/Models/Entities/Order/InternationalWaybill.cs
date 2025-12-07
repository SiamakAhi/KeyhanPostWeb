namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class InternationalWaybill
    {
        public int Id { get; set; }
        public string WaybillNumber {  get; set; }  
        public int PackageCount { get; set; }
        public double PackageWeight { get; set; }

        public string OriginCountryName { get; set; }
        public string DestinationCountryName { get; set; }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

        public int WaybillCounter { get; set; }

        // فقط جهت نمایش آخرین وضعیت =
        public string CurrentStatus { get; set; }
        public int CurrentStatusId { get; set; }    
        public DateTime CreateAt { get; set; }

        // ارتباط با تاریخچه

        public virtual ICollection<WaybillStatusHistory> WaybillStatusHistory { get; set; }
    }
}
