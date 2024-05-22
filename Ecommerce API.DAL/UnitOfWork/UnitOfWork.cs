using Ecommerce_API.DAL.Data.Context;
using Ecommerce_API.DAL.Rebos.CartrsRebos;
using Ecommerce_API.DAL.Rebos.OrdersRebos;
using Ecommerce_API.DAL.Rebos.ProductsRebos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL;

    public class UnitOfWork :IUnitOfWork
    {
        private readonly SystemContext _Context;
        public UnitOfWork(SystemContext DbContext, IProductsRepo productsRepos, ICartsRepo cartsRepo, IOrdersRepo ordersRepo)
        {
            _Context = DbContext;
            productRepositary = productsRepos;
            cartRepository = cartsRepo;
             orderRepositary = ordersRepo;
        }
        public IProductsRepo productRepositary { get; }
        public ICartsRepo cartRepository { get; }
        public IOrdersRepo orderRepositary { get; }

        public void SaveChanges()
        {
        }

    }

