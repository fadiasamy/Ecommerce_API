using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Data.Models
{
    [PrimaryKey(nameof(CartId), nameof(ProductId))]

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } = new Product();
        public int CartId { get; set; }
        public Cart cart { get; set; } = new Cart();


    }
}
