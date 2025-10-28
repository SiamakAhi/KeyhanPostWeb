using System.ComponentModel;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class OrderStatusDto
    {
        public int Id { get; set; }

        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }
    }
}
