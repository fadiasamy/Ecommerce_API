using Ecommerce_API.BL.Dtos.Order;
using Ecommerce_API.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Managers.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddNewOrder(List<AddOrderDto> newOrder, string UserId)
        {
            List<(int ProductId, int Quantity)> orderItems = newOrder
           .Select(dto => (dto.ProductId, dto.Quantity))
             .ToList();
            _unitOfWork.orderRepositary.AddNewOrder(orderItems, UserId);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<GetOrderHistoryDto> GetAllOrder(string userId)
        {
            var orders = _unitOfWork.orderRepositary.GetAllOrder(userId);
            if (orders is null) return null;
            return orders.Select(p => new GetOrderHistoryDto
            {
                OrderId = p.OrderId,
                OrderDate = p.OrderDate,
                TotalPrice = p.TotalPrice,


            });
        }
    }
}
