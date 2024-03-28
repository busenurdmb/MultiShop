using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create.CreateAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete.DeleteAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update.UpdateAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById.GetByIdAddressQuery;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList.GetListAddressQuery;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create.CreateOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete.DeleteOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update.UpdateOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById.GetByIdOrderDetailQuery;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList.GetListOrderDetailQuery;

namespace MultiShop.Order.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

             services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));

            services.AddScoped<GetListAddressQueryHandler>();
            services.AddScoped<GetByIdAddressQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<DeleteAddressCommandHandler>();


            services.AddScoped<GetListOrderDetailQueryHandler>();
            services.AddScoped<GetByIdOrderDetailQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<DeleteOrderDetailCommandHandler>();




            //services.AddMediatR(configuration =>
            //{
            //    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());


            //});

        }
    }
}
