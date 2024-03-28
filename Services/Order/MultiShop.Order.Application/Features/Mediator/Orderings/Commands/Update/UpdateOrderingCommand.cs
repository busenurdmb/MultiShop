using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;


namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Update
{
  
    public class UpdateOrderingCommand:IRequest<UpdateOrderingResponse>
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public class UpdateOrderingCommandHandler:IRequestHandler<UpdateOrderingCommand,UpdateOrderingResponse>
        {
            private readonly IOrderingRepository _orderingRepository;
            private readonly IMapper _mapper;

            public UpdateOrderingCommandHandler(IOrderingRepository OrderingRepository, IMapper mapper)
            {
                _orderingRepository = OrderingRepository;
                _mapper = mapper;
            }
        

            public async Task<UpdateOrderingResponse> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
            {
                Ordering? Ordering = await _orderingRepository.GetByFilterAsync(x => x.OrderingId == request.OrderingId);
                Ordering = _mapper.Map(request, Ordering);
                await _orderingRepository.UpdateAsync(Ordering);
                return _mapper.Map<UpdateOrderingResponse>(Ordering);
            }
        }
    }
}

