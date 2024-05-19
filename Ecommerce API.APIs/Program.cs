using Ecommerce_API.BL;
using Ecommerce_API.DAL;
using Ecommerce_API.DAL.Data.Context;
using Ecommerce_API.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Text;
using static Ecommerce_API.APIs.Constant;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///DAL
builder.Services.AddDALServices(builder.Configuration);
////BL
builder.Services.AddBLServices();

//cors
/*const string AllowAllCorsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllCorsPolicy, b =>
    {
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});*/

//Identity

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<SystemContext>();



// Authentication

builder.Services.AddAuthentication(options =>
{
    // Configure used authentication 
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault"; // return 401 if not authenticated, 403 if authenticated but not authorized
})
    // Define the authentication scheme
    .AddJwtBearer("MyDefault", options =>
    {
        var keyFromConfig = builder.Configuration.GetValue<string>(AppSettings.SecretKey)!;
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });



var connectionString = builder.Configuration.GetConnectionString("EcommerceSystem1") ?? throw new InvalidOperationException("Connection string 'EcommerceSystem' not found.");
builder.Services.AddDbContext<SystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceSystem1")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
