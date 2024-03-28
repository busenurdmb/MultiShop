using AutoMapper;

using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailResponse>().ReverseMap();

            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailResponse>().ReverseMap();

            CreateMap<OrderDetail, DeleteOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, DeleteOrderDetailResponse>().ReverseMap();

            CreateMap<OrderDetail, GetListOrderDetailResponse>().ReverseMap();
            CreateMap<OrderDetail, GetByIdOrderDetailResponse>().ReverseMap();
        }
    }
}
