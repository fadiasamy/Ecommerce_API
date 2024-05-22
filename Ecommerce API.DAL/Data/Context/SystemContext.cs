using Ecommerce_API.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce_API.DAL.Data.Context
{
    public class SystemContext : IdentityDbContext<User>
    {
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    public SystemContext(DbContextOptions  options)
     : base(options)
    {

    }         
      // This constructor forces me to enter my Connection string to use my Context in any connection string (SQl ,sql server,... to be flexable
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<OrderItem>()
        .HasOne(e => e.Product)
        .WithMany(product => product.OrderItems)
        .HasForeignKey(item => item.ProductId);

        builder.Entity<CartItem>()
        .HasOne(e => e.Product)
        .WithMany(product => product.CartItems)
        .HasForeignKey(item => item.ProductId);

        builder.Entity<OrderItem>()
       .HasOne(e => e.Order)
        .WithMany(order => order.OrderItems)
        .HasForeignKey(item => item.OrderId);

        builder.Entity<CartItem>()
        .HasOne(item => item.cart)
        .WithMany(cart => cart.CartItems)
        .HasForeignKey(item => item.CartId);

        builder.Entity<Cart>()
            .HasOne(item => item.User)
            .WithOne(cart => cart.Cart);

        builder.Entity<Order>()
       .HasOne(item => item.User)
       .WithMany(order => order.Orders)
       .HasForeignKey(r => r.UserId);

        builder.Entity<Product>()
       .HasOne(item => item.Category)
       .WithMany(e => e.products)
       .HasForeignKey(r => r.CategoryId);

        #region Seeding  products

        var products = new List<Product>
        {
          new Product {ProductId= 1,ProductName= "Productone",Description ="good productdetail about Product1",CategoryId=1,Price=5000,Color="black"},
          new Product {ProductId= 2,ProductName= "Producttwo",Description ="good productdetail about Product2",CategoryId=3,Price=90000,Color="White"},
          new Product {ProductId= 3,ProductName= "Productthree",Description ="good productdetail about Product3",CategoryId=2,Price=80000,Color="blue"}
        };
        #endregion
        #region Seeding CategorieBlacks
        var Categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Category1"},
                new Category{CategoryId=2,CategoryName="Category2"},
                new Category{CategoryId=3,CategoryName="Category3"}

            };
        #endregion

        builder.Entity<Product>().HasData(products);
        builder.Entity<Category>().HasData(Categories);

    }

}
}
