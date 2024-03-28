using AutoMapper;
using MultiShop.Order.Application.Repositories;


namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete
{
    
    public class DeleteOrderDetailCommand
    {
        public int Id { get; set; }

        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }
        public class DeleteOrderDetailCommandHandler
        {
            private readonly IOrderDetailRepository _orderDetailRepository;
            private readonly IMapper _mapper;

            public DeleteOrderDetailCommandHandler(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
            {
                _orderDetailRepository = OrderDetailRepository;
                _mapper = mapper;
            }
            public async Task<DeleteOrderDetailResponse> Handle(DeleteOrderDetailCommand Request)
            {
                var OrderDetail = await _orderDetailRepository.GetByIdAsync(Request.Id);
                await _orderDetailRepository.RemoveAsync(OrderDetail);
                return _mapper.Map<DeleteOrderDetailResponse>(OrderDetail);

            }
        }
    }
}
