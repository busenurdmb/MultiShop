using AutoMapper;

using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create
{
   
    public class CreateOrderDetailCommand
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }

        public class CreateOrderDetailCommandHandler
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;

            public CreateOrderDetailCommandHandler(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
            {
                _orderDetailRepository = OrderDetailRepository;
                _mapper = mapper;
            }

            public async Task<CreateOrderDetailResponse> Handle(CreateOrderDetailCommand request)
            {
                var OrderDetail = _mapper.Map<OrderDetail>(request);

                await _orderDetailRepository.CreateAsync(OrderDetail);

                return _mapper.Map<CreateOrderDetailResponse>(OrderDetail);
            }
        }

    }
}
