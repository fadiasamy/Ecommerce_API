using Ecommerce_API.DAL.Data.Context;
using Ecommerce_API.DAL.Data.Models;
using Ecommerce_API.DAL.Rebos.GenericRebos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Rebos.ProductsRebos
{
    public class ProductsRepo : GenericRepo<Product>, IProductsRepo
    {
        private readonly SystemContext _Context;
        public ProductsRepo(SystemContext context) : base(context)
        {
            _Context = context;
        }
        public IEnumerable<Product>? GetByCategory(int IdCat)
        {
            return _Context.Set<Product>().Where(x => x.CategoryId == IdCat);
        }

        public Product? GetById(int id)
        {
            return _Context.Set<Product>().Include(e => e.Category).FirstOrDefault(x => x.CategoryId == id);
        }

        public IEnumerable<Product>? GetByName(string ProductName)
        {
            return _Context.Set<Product>().Where(x => x.ProductName == ProductName);
        }
    }
}
