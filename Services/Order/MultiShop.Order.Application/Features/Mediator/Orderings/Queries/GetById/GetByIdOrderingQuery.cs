using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Repositories;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById
{

    public class GetByIdOrderingQuery:IRequest<GetByIdOrderingResponse>
    {
        public int Id { get; set; }

        public GetByIdOrderingQuery(int ıd)
        {
            Id = ıd;
        }
        public class GetByIdOrderingQueryHandle:IRequestHandler<GetByIdOrderingQuery, GetByIdOrderingResponse>
        {
            private readonly IOrderingRepository _orderingRepository;
            private readonly IMapper _mapper;

            public GetByIdOrderingQueryHandle(IOrderingRepository OrderingRepository, IMapper mapper)
            {
                _orderingRepository = OrderingRepository;
                _mapper = mapper;
            }
         

            public async Task<GetByIdOrderingResponse> Handle(GetByIdOrderingQuery request, CancellationToken cancellationToken)
            {
                var Ordering = await _orderingRepository.GetByFilterAsync(x => x.OrderingId == request.Id);
                return _mapper.Map<GetByIdOrderingResponse>(Ordering);
            }
        }
    }
}
