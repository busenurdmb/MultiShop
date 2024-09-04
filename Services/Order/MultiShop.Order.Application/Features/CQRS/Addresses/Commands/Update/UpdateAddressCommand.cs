using AutoMapper;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update
{
    public class UpdateAddressCommand
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Description { get; set; }
        public string ZipCode { get; set; }
        public class UpdateAddressCommandHandler
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }
            public async Task<UpdateAddressResponse> Handle(UpdateAddressCommand request)
            {
                Address? Address= await _addressRepository.GetByFilterAsync(x=>x.AddressId==request.AddressId);
                 Address = _mapper.Map(request, Address);
               await _addressRepository.UpdateAsync(Address);
                return _mapper.Map<UpdateAddressResponse>(Address);
            }
        }
    }
}
