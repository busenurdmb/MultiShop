using AutoMapper;
using MultiShop.Order.Application.Repositories;


namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList
{
    public class GetListOrderDetailQuery
    {
        public class GetListOrderDetailQueryHandler
        {
            private readonly IOrderDetailRepository _OrderDetailRepository;
            private readonly IMapper _mapper;

            public GetListOrderDetailQueryHandler(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
            {
                _OrderDetailRepository = OrderDetailRepository;
                _mapper = mapper;
            }
            public async Task<List<GetListOrderDetailResponse>> Handle()
            {
                var OrderDetails = await _OrderDetailRepository.GetAllAsync();
                return _mapper.Map<List<GetListOrderDetailResponse>>(OrderDetails);
            }
        }
    }
}
