using Ecommerce_API.DAL.Rebos.CartrsRebos;
using Ecommerce_API.DAL.Rebos.OrdersRebos;
using Ecommerce_API.DAL.Rebos.ProductsRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL;

public interface IUnitOfWork
{
    public IProductsRepo productRepositary { get; }
    public ICartsRepo cartRepository { get; }
    public IOrdersRepo orderRepositary { get; }

    void SaveChanges();
}
