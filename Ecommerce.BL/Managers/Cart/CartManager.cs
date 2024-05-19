using Ecommerce_API.BL.Dtos.Cart;
using Ecommerce_API.DAL;
using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.CartrsRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Managers.Cart
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProductToCart(int productId, int Quentity, string UserId)
        {
            _unitOfWork.cartRepository.AddProductToCart(productId, Quentity, UserId);
            _unitOfWork.SaveChanges();

        }

        public void RemoveProductFromCart(int productId, string UserId)
        {
            _unitOfWork.cartRepository.RemoveProductFromCart(productId, UserId);
            _unitOfWork.SaveChanges();

        }

        public void UpadteProductQuentity(int productId, int Quentity, string UserId)
        {
            _unitOfWork.cartRepository.UpadteProductQuentity(productId, Quentity, UserId);
            _unitOfWork.SaveChanges();


        }
    }
}
