using AutoMapper;
using MultiShop.Order.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList
{
    public class GetListAddressQuery
    {
        public class GetListAddressQueryHandler
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }
            public async Task<List<GetListAddressResponse>> Handle()
            {
              var Adress=  await _addressRepository.GetAllAsync();
                return _mapper.Map<List<GetListAddressResponse>>(Adress);   
            }
        }
    }
}
