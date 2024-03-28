using AutoMapper;
using MultiShop.Order.Application.Repositories;


namespace MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById
{
   
    public class GetByIdOrderDetailQuery
    {
        public int Id { get; set; }

        public GetByIdOrderDetailQuery(int ıd)
        {
            Id = ıd;
        }
        public class GetByIdOrderDetailQueryHandle
        {
            private readonly IOrderDetailRepository _OrderDetailRepository;
            private readonly IMapper _mapper;

            public GetByIdOrderDetailQueryHandle(IOrderDetailRepository OrderDetailRepository, IMapper mapper)
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
