using AutoMapper;
using MultiShop.Order.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById
{
    public class GetByIdAddressQuery
    {
        public int Id { get; set; }

        public GetByIdAddressQuery(int id)
        {
            Id = id;
        }
      public class GetByIdAddressQueryHandler
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public GetByIdAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }
            public async Task<GetByIdAddressResponse> Handle(GetByIdAddressQuery request)
            {
                var Address=await _addressRepository.GetByFilterAsync(x=>x.AddressId==request.Id);
                return _mapper.Map<GetByIdAddressResponse>(Address);

            }
        }
    }
}
