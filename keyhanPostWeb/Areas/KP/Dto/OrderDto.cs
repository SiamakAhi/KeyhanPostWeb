namespace keyhanPostWeb.Areas.KP.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        // --- نوع بسته ---
        public short PackageTypeId { get; set; }
        

        // --- شهر مبدا ---
        public int OriginCityId { get; set; }
        public string OriginCityName { get; set; }

        // --- شهر مقصد ---
        public int DestinationCityId { get; set; }
        public string DestinationCityName { get; set; }

        // --- ابعاد و وزن ---
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double ActualWeight { get; set; }

        // --- اطلاعات فرستنده ---
        public string SenderName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderNationalId { get; set; }
        public string SenderAddress { get; set; }

        // --- اطلاعات گیرنده ---
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverNationalId { get; set; }
        public string ReceiverAddress { get; set; }

        // --- وضعیت سفارش ---
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        // --- سایر اطلاعات ---
        public string TrackingCode { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
