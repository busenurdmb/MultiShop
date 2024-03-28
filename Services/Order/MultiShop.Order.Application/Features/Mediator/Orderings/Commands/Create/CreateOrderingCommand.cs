using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;


namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Create
{
    public class CreateOrderingCommand:IRequest<CreateOrderingResponse>
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public class CreateOrderingCommandHandler:IRequestHandler<CreateOrderingCommand,CreateOrderingResponse>
        {
            private readonly IOrderingRepository _orderingRepository;
            private readonly IMapper _mapper;

            public CreateOrderingCommandHandler(IOrderingRepository orderingRepository, IMapper mapper)
            {
                _orderingRepository = orderingRepository;
                _mapper = mapper;
            }

            public async Task<CreateOrderingResponse> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
            {
                var Ordering = _mapper.Map<Ordering>(request);

                await _orderingRepository.CreateAsync(Ordering);

                return _mapper.Map<CreateOrderingResponse>(Ordering);
            }
        }
    }
}
