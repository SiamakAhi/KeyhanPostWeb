namespace keyhanPostWeb.Areas.KP.Dto
{
    public class InternationalWaybillFilterDto
    {
        public string? WaybillNumber { get; set; }
        public string? OriginCountryName { get; set; }
        public string? DestinationCountryName { get; set; }
        public string? SenderName { get; set; }
        public string? ReceiverName { get; set; }
        public int? CurrentStatusId { get; set; }      // برای == 
        public int? ExcludeStatusId { get; set; }      // ✅ برای !=
    }
}
