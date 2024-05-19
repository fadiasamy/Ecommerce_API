using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.OrdersRebos
{
    public interface IOrdersRepo : IGenericRepo<Order>
    {
        void AddNewOrder(List<(int ProductId, int Quntity)> newOrder, string UserId);
        IEnumerable<Order> GetAllOrder(string UserId);
    }
}
