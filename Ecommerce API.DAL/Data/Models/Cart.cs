using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Data.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = new User();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();

    }
}
