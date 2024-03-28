using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories
{
    public class OrderDetailRepository : EfEntityRepository<OrderDetail, OrderContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(OrderContext context) : base(context)
        {
        }
    }
}
