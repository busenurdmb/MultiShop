using AutoMapper;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create
{
    public class CreateAddressCommand
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }

          public class CreateAddressCommandHandler
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }

            public async Task<CreateAddressResponse> Handle(CreateAddressCommand request)
            {
                var Adress=_mapper.Map<Address>(request);

                await _addressRepository.CreateAsync(Adress);

                return _mapper.Map<CreateAddressResponse>(Adress);
            }
        }
       
    }
}
