using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;


namespace MultiShop.Order.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IOrderingRepository, OrderingRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<OrderContext>();
    }
}
}
