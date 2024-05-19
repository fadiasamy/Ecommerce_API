using Ecommerce_API.BL.Dtos.Product;
using Ecommerce_API.BL.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Managers.Products
{
    public interface IProductsManager
    {
        IEnumerable<GetProductDto> GetAll();
        GetProductDetailsDto? GetById(int ProductId);
        IEnumerable<GetProductDto>? GetByName(string ProductName);
        IEnumerable<GetProductDto>? GetByCategory(int CategoryId);
    }
}
