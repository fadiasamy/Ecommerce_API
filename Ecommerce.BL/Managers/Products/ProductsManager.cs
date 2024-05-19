using Ecommerce_API.BL.Dtos.Product;
using Ecommerce_API.BL.Dtos.Products;
using Ecommerce_API.DAL;
using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.ProductsRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Managers.Products
{
    public class ProductsManager : IProductsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<GetProductDto> GetAll()
        {
            var products = _unitOfWork.productRepositary.GetAll();
            if (products is null) return null;
            return products.Select(p => new GetProductDto
            {
                ProductId = p.ProductId,
                Description = p.Description,
                ProductName = p.ProductName,
                Price = p.Price,
            });
        }

        public IEnumerable<GetProductDto>? GetByCategory(int CategoryId)
        {
            var products = _unitOfWork.productRepositary.GetByCategory(CategoryId);
            if (products is null) return null;
            return products.Select(p => new GetProductDto
            {
                ProductId = p.ProductId,
                Description = p.Description,
                ProductName = p.ProductName,
                Price = p.Price,
            });
        }


        public IEnumerable<GetProductDto>? GetByName(string Name)
        {
            var products = _unitOfWork.productRepositary.GetByName(Name);
            if (products is null) return null;
            return products.Select(p => new GetProductDto
            {
                ProductId = p.ProductId,
                Description = p.Description,
                ProductName = p.ProductName,
                Price = p.Price,
            });
        }
        public GetProductDetailsDto? GetById(int id)
        {
            var product = _unitOfWork.productRepositary.GetById(id);
            if (product is null) return null;

            return new GetProductDetailsDto
            {
                ProductId = product.ProductId,
                Description = product.Description,
                ProductName = product.ProductName,
                Price = product.Price,
                CategoryName = product?.Category?.CategoryName,
                Color = product.Color,
            };
        }
    }
}
