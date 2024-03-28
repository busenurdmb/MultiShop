using AutoMapper;
using MultiShop.Order.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete
{
    public class DeleteAddressCommand
    {
        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
        public class DeleteAddressCommandHandler
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;

            public DeleteAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }
            public async Task<DeleteAddressResponse> Handle(DeleteAddressCommand Request)
            {
                var Address=await _addressRepository.GetByIdAsync(Request.Id);
              await  _addressRepository.RemoveAsync(Address);
                return _mapper.Map<DeleteAddressResponse>(Address);

            }
        }
    }
}
