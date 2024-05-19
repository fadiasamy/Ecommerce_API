using Ecommerce_API.DAL.Rebos.CartrsRebos;
using Ecommerce_API.DAL.Rebos.OrdersRebos;
using Ecommerce_API.DAL.Rebos.ProductsRebos;
using Ecommerce_API.DAL.Repos.CartrsRepos;
using Ecommerce_API.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL
{
    public static class ServiceExtentions
    {
        public static void AddDALServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICartsRepo, CartsRepo>();

            services.AddScoped<IOrdersRepo, OrdersRepo>();

            services.AddScoped<IProductsRepo, ProductsRepo>();

            services.AddScoped<IUnitOfWork, UnitOfWork >();
        }
    }
}
