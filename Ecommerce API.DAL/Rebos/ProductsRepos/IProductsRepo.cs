using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.ProductsRebos
{
    public interface IProductsRepo : IGenericRepo<Product>
    {
        Product? GetById(int id);
        IEnumerable<Product>? GetByName(string Name);
        IEnumerable<Product>? GetByCategory(int IdCat);
    }
}
