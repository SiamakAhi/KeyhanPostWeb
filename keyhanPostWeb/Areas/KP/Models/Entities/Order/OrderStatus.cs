using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace keyhanPostWeb.Areas.KP.Models.Entities.Order
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("عنوان وضعیت")]
        [Required, MaxLength(50)]
        public string Title { get; set; }

        [DisplayName("توضیحات")]
        [MaxLength(200)]
        public string Description { get; set; }

        // Navigation
        public virtual ICollection<Order> Orders { get; set; }
    }
}
