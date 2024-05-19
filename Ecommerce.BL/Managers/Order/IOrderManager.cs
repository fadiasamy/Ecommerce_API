using Ecommerce_API.BL.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Managers.Order
{
    public interface IOrderManager
    {
        void AddNewOrder(List<AddOrderDto> newOrder, string UserId);
        IEnumerable<GetOrderHistoryDto> GetAllOrder(string userId);

    }
}
