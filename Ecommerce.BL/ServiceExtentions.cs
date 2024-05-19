using Ecommerce_API.BL.Managers.Cart;
using Ecommerce_API.BL.Managers.Order;
using Ecommerce_API.BL.Managers.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL
{
    public static class ServiceExtentions 
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderManager, OrderManager>();


            services.AddScoped<IProductsManager, ProductsManager>();

            services.AddScoped<ICartManager, CartManager>();

        }
    }
}
