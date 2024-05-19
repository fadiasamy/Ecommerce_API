using Ecommerce_API.DAL.Data.Context;
using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.OrdersRebos
{
    public class OrdersRepo : GenericRepo<Order>, IOrdersRepo
    {
        public readonly SystemContext _Context;

        public OrdersRepo(SystemContext context) : base(context)
        {
            _Context = context;
        }

        public void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId)
        {
            var cart = _Context.Set<Cart>()
                      .FirstOrDefault(c => c.UserId == UserId);
            if (cart != null)
            {
                // Create a new order
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    UserId = UserId,

                    OrderItems = new List<OrderItem>()
                };
                _Context.Set<Order>().Add(order);
                _Context.SaveChanges();
                // Add order items from the provided list

                decimal total = 0;
                foreach (var obj in newOrder)
                {
                    var product = _Context.Set<Product>().Find(obj.ProductId);
                    if (product != null)
                    {
                        var orderItem = new OrderItem
                        {
                            ProductId = obj.ProductId,
                            Quantity = obj.ProductId,
                            OrderId = order.OrderId
                        };
                        _Context.Set<OrderItem>().Add(orderItem);
                        total += obj.Quntity * (decimal)product.Price;

                        order.TotalPrice = total;
                        // Add the order to the context and save changes

                        _Context.SaveChanges();
                        var cartItem = cart?.CartItems?.FirstOrDefault(e => e.ProductId == obj.ProductId);
                        if (cartItem != null)
                        {
                            cart?.CartItems?.Remove(cartItem);
                            _Context.SaveChanges();
                        }

                    }
                }
                _Context.SaveChanges();
            }

        }






        public IEnumerable<Order> GetAllOrder(string userId)
        {
            return _Context.Set<Order>()
               .Where(c => c.UserId == userId);
        }
    }
}
