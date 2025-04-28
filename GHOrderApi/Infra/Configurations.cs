using GHOrderApi.Repositories;
using GHOrderApi.Repositories.Interfaces;
using GHOrderApi.Services;
using GHOrderApi.Services.Interfaces;

namespace GHOrderApi.Infra
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
            services.AddSingleton<IOrderService, OrderServices>();
            services.AddSingleton<IOrderItemService, OrderItemServices>();
        }
    }
}
