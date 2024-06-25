using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("orderstatus")]
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        public string Status { get; set; }
    }
}
