using GH.Application.Services;
using GH.Domain.Interfaces.Repositories;
using GH.Domain.Interfaces.Services;
using GH.Infrastructure.Repositories;

namespace GH.WebAPI.Configurations
{
    public static class Configurations
    {
        /// <summary>
        /// Register all services in the application.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderItemRepository, OrderItemRepository>();

            // Services
            services.AddScoped<IOrderService, OrderServices>();
            services.AddScoped<IOrderItemService, OrderItemServices>();
        }
    }
}
