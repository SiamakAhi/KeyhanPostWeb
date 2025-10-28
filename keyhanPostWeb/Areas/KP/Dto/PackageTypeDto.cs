using System.ComponentModel;

namespace keyhanPostWeb.Areas.KP.Dto
{
    public class PackageTypeDto
    {
        public int Id { get; set; }

        [DisplayName("عنوان نوع بسته")]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }
    }
}
