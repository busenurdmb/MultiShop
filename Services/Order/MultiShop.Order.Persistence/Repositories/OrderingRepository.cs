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
    public class OrderingRepository : EfEntityRepository<Ordering, OrderContext>, IOrderingRepository
    {
        public OrderingRepository(OrderContext context) : base(context)
        {
        }
    }
}
