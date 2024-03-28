using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Repositories;


namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList
{
    
    public class GetListOrderingQuery:IRequest<List<GetListOrderingResponse>>
    {
        public class GetListOrderingQueryHandler:IRequestHandler<GetListOrderingQuery,List<GetListOrderingResponse>>
        {
            private readonly IOrderingRepository _OrderingRepository;
            private readonly IMapper _mapper;

            public GetListOrderingQueryHandler(IOrderingRepository OrderingRepository, IMapper mapper)
            {
                _OrderingRepository = OrderingRepository;
                _mapper = mapper;
            }
       

            public async Task<List<GetListOrderingResponse>> Handle(GetListOrderingQuery request, CancellationToken cancellationToken)
            {
                var Ordering = await _OrderingRepository.GetAllAsync();
                return _mapper.Map<List<GetListOrderingResponse>>(Ordering);
            }
        }
    }
}
