using AutoMapper;
using MultiShop.Order.Application.Repositories;


namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById
{
   
    public class GetByIdOrderDetailQuery
    {
        public int Id { get; set; }

        public GetByIdOrderDetailQuery(int id)
        {
            Id = id;
        }
        public class GetByIdOrderDetailQueryHandler
        {
            private readonly IOrderDetailRepository _OrderDetailRepository;
            private readonly IMapper _mapper;

            public GetByIdOrderDetailQueryHandler(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
            {
                _OrderDetailRepository = OrderDetailRepository;
                _mapper = mapper;
            }
            public async Task<GetByIdOrderDetailResponse> Handle(GetByIdOrderDetailQuery request)
            {
                var OrderDetail = await _OrderDetailRepository.GetByFilterAsync(x => x.OrderDetailId == request.Id);
                return _mapper.Map<GetByIdOrderDetailResponse>(OrderDetail);

            }
        }
    }
}
