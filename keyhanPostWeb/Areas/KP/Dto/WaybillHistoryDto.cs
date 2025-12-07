namespace keyhanPostWeb.Areas.KP.Dto
{
    public class WaybillHistoryDto
    {
        public string WaybillNumber { get; set; }
        public string CurrentStatus { get; set; }

        public string OriginCountryName { get; set; }
        public string DestinationCountryName { get; set; }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

        public int PackageCount { get; set; }
        public double PackageWeight { get; set; }
        public DateTime CreateAt { get; set; }

        public List<WaybillHistoryItemDto> History { get; set; }
    }
}
