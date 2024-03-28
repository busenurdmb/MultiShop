using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Repositories;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Delete
{

    public class DeleteOrderingCommand:IRequest<DeleteOrderingResponse>
    {
        public int Id { get; set; }

        public DeleteOrderingCommand(int id)
        {
            Id = id;
        }
        public class DeleteOrderingCommandHandler:IRequestHandler<DeleteOrderingCommand,DeleteOrderingResponse>
        {
            private readonly IOrderingRepository _orderingRepository;
            private readonly IMapper _mapper;

            public DeleteOrderingCommandHandler(IOrderingRepository OrderingRepository, IMapper mapper)
            {
                _orderingRepository = OrderingRepository;
                _mapper = mapper;
            }
          

            public async Task<DeleteOrderingResponse> Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
            {
                var Ordering = await _orderingRepository.GetByIdAsync(request.Id);
                await _orderingRepository.RemoveAsync(Ordering);
                return _mapper.Map<DeleteOrderingResponse>(Ordering);
            }
        }
    }
}
