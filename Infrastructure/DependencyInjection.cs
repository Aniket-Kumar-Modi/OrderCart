using Application.CartItems;
using Application.Products;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("con");
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("OrderCart"));
            //services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(connectionString));
            services.AddSingleton<IProductService, ProductService>();
            services.AddScoped<ICartItemsService, CartService>();
            return services;
        }
    }
}