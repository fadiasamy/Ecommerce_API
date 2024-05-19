using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryId { get; set; } 
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public ICollection<CartItem> CartItems { get; set; }= new HashSet<CartItem>();
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();


    }
}
