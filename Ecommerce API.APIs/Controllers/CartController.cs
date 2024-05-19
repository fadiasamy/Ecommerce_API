using Ecommerce_API.BL.Dtos.Cart;
using Ecommerce_API.BL.Managers.Cart;
using Ecommerce_API.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManeger;
        private readonly UserManager<User> _userManage;
        public CartController(ICartManager cartManeger, UserManager<User> userManage)
        {
            _cartManeger = cartManeger;
            _userManage = userManage;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProductToCart(AddToCartDto addToCartDto)
        {
            User? user = await _userManage.GetUserAsync(User);

            _cartManeger.AddProductToCart(addToCartDto.ProductId, addToCartDto.Quantity, user.Id);

            return Ok("product is added to cart");

        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveProductFromCart(int id)
        {
            User? user = await _userManage.GetUserAsync(User);
            _cartManeger.RemoveProductFromCart(id, user.Id);
            return Ok("product is deleted from cart");
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpadteProductQuentity(EditQuantityInCartDto editQuantityInCartDto)
        {
            User? user = await _userManage.GetUserAsync(User);

            _cartManeger.UpadteProductQuentity(editQuantityInCartDto.ProductId,
             editQuantityInCartDto.Quantity, user.Id);
            return Ok("product  is updated successfully");
        }

    }
}

