﻿using Ecommerce_API.BL.Dtos.Cart;
using Ecommerce_API.BL.Dtos.Order;
using Ecommerce_API.BL.Managers.Order;
using Ecommerce_API.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManeger;
        private readonly UserManager<User> _userManage;
        public OrderController(IOrderManager orderManeger, UserManager<User> userManage)
        {
            _orderManeger = orderManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNewOrder(List<AddOrderDto> newOrder)
        {
            User? user = await _userManage.GetUserAsync(User);


            _orderManeger.AddNewOrder(newOrder, user.Id);
            return Ok("order is added successfully");

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrderHistoryDto>>> GetAllOrder()
        {
            User? user = await _userManage.GetUserAsync(User);

            var orders = _orderManeger.GetAllOrder(user.Id);
            return orders.ToList();
        }


    }
}

