using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderProducts { get; set; } = [];
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
        public User User { get; set; } = new User();
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
