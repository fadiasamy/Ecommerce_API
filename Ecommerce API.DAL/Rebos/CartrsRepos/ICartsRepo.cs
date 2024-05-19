using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.CartrsRebos
{
    public interface ICartsRepo : IGenericRepo<Cart>
    {
        void AddProductToCart(int productId, int Quentity, string UserId);
        void RemoveProductFromCart(int productId, string UserId);
        void UpadteProductQuentity(int productId, int Quentity, string UserId);
    }
}
