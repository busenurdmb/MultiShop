using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList;
using System.Reflection;

namespace MultiShop.Order.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<CreateAddressCommand>();
            services.AddScoped<UpdateAddressCommand>();
            services.AddScoped<DeleteAddressCommand>();
            services.AddScoped<GetListAddressQuery>();
            services.AddScoped<GetByIdAddressQuery>();

            services.AddScoped<CreateOrderDetailCommand>();
            services.AddScoped<UpdateOrderDetailCommand>();
            services.AddScoped<DeleteOrderDetailCommand>();
            services.AddScoped<GetListOrderDetailQuery>();
            services.AddScoped<GetByIdOrderDetailQuery>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));

            //services.AddMediatR(configuration =>
            //{
            //    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());


            //});

        }
    }
}
