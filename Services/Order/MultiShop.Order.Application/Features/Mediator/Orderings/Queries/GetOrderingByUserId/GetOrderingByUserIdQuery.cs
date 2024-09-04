using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById;
using MultiShop.Order.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetOrderingByUserId
{
    public class GetOrderingByUserIdQuery:IRequest<List<GetOrderingByUserIdResponse>>
    {
        public string Id { get; set; }

        public GetOrderingByUserIdQuery(string ıd)
        {
            Id = ıd;
        }

        public class GetOrderingByUserIdHandle : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdResponse>>
        {
            private readonly IOrderingRepository _orderingRepository;
            private readonly IMapper _mapper;

            public GetOrderingByUserIdHandle(IOrderingRepository orderingRepository, IMapper mapper)
            {
                _orderingRepository = orderingRepository;
                _mapper = mapper;
            }

            //public async Task<GetByIdOrderingResponse> Handle(GetByIdOrderingQuery request, CancellationToken cancellationToken)
            //{
            //    var Ordering = await _orderingRepository.GetByFilterAsync(x => x.OrderingId == request.Id);
            //    return _mapper.Map<GetByIdOrderingResponse>(Ordering);
            //}

            public async Task<List<GetOrderingByUserIdResponse>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
            {
                var Ordering = await _orderingRepository.GetByUserIdAsync(request.Id);
                return _mapper.Map<List<GetOrderingByUserIdResponse>>(Ordering);
            }
        }
    }
}
