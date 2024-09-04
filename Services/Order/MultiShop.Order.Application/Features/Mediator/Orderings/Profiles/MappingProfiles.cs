using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Delete;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetOrderingByUserId;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, CreateOrderingResponse>().ReverseMap();

            CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingResponse>().ReverseMap();

            CreateMap<Ordering, DeleteOrderingCommand>().ReverseMap();
            CreateMap<Ordering, DeleteOrderingResponse>().ReverseMap();

            CreateMap<Ordering, 
GetListOrderingResponse>().ReverseMap();
            CreateMap<Ordering, GetByIdOrderingResponse>().ReverseMap();

            
            CreateMap<Ordering, GetOrderingByUserIdResponse>().ReverseMap();
        }
    }
}
