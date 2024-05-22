using Ecommerce_API.DAL.Data.Context;
using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.CartrsRebos;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Repos.CartrsRepos
{
    public class CartsRepo : GenericRepo<Cart>, ICartsRepo

    {
        public readonly SystemContext _Context;
        public CartsRepo(SystemContext Context) : base(Context)
        {
            _Context = Context;
        }

        public void AddProductToCart(int productId, int Quentity, string UserId)
        {

            var cart = _Context.Set<Cart>()
                      .FirstOrDefault(c => c.UserId == UserId);

            if (cart == null)
            {
                // Create a new cart if it doesn't exist for the user
                cart = new Cart
                {
                    UserId = UserId,
                    CartItems = new List<CartItem>()
                };
                _Context.Set<Cart>().Add(cart);
                _Context.SaveChanges();
            }

            // Create a new cart item based on the provided productId and quantity
            var product = _Context.Products.Find(productId);
            if (product != null)
            {

                var cartItem = _Context.Set<CartItem>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.CartId);
                if (cartItem != null)
                {
                    cartItem.Quantity += Quentity;
                }
                else
                {
                    var newcartItem = new CartItem
                    {
                        ProductId = productId,
                        Quantity = Quentity,
                        CartId = cart.CartId
                    };

                    _Context.Set<CartItem>().Add(newcartItem);
                    _Context.SaveChanges();


                }

            }

            _Context.SaveChanges();

        }

        public void RemoveProductFromCart(int productId, string User2Id)
        {

            var cart = _Context.Set<Cart>()
                        .FirstOrDefault(c => c.UserId == User2Id);

            if (cart != null)
            {
                var cartItem = _Context.Set<CartItem>().FirstOrDefault(item => item.CartId == cart.CartId&& item.ProductId == productId);
                if (cartItem != null)
                {
                    _Context.Set<CartItem>().Remove(cartItem);
                    _Context.SaveChanges();
                }
            }

        }

        public void UpadteProductQuentity(int productId, int Quentity, string UserId)
        {
            //var userId = UserId;
            var cart = _Context.Set<Cart>()
                      .FirstOrDefault(c => c.UserId == UserId);
            if (cart != null)
            {
                var cartItem = _Context.Set<CartItem>().FirstOrDefault(item => item.ProductId == productId && item.CartId == cart.CartId);
                if (cartItem != null)
                {
                    cartItem.Quantity = Quentity;

                    _Context.SaveChanges();
                }

            }

        }
    }
}
