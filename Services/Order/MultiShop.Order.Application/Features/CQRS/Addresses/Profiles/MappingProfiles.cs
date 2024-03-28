using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, CreateAddressResponse>().ReverseMap();

            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressResponse>().ReverseMap();

            CreateMap<Address, DeleteAddressCommand>().ReverseMap();
            CreateMap<Address, DeleteAddressResponse>().ReverseMap();

            CreateMap<Address, GetListAddressResponse>().ReverseMap();
            CreateMap<Address, GetByIdAddressResponse>().ReverseMap();
        }
    }
}
