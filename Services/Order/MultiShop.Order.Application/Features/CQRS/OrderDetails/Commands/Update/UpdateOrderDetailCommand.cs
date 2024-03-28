using AutoMapper;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;


namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update
{
   
    public class UpdateOrderDetailCommand
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
        public class UpdateOrderDetailCommandHandler
        {
            private readonly IOrderDetailRepository _OrderDetailRepository;
            private readonly IMapper _mapper;

            public UpdateOrderDetailCommandHandler(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
            {
                _OrderDetailRepository = OrderDetailRepository;
                _mapper = mapper;
            }
            public async Task<UpdateOrderDetailResponse> Handle(UpdateOrderDetailCommand request)
            {
                OrderDetail? OrderDetail = await _OrderDetailRepository.GetByFilterAsync(x => x.OrderDetailId == request.OrderDetailId);
                OrderDetail = _mapper.Map(request, OrderDetail);
                await _OrderDetailRepository.UpdateAsync(OrderDetail);
                return _mapper.Map<UpdateOrderDetailResponse>(OrderDetail);
            }
        }
    }
}
