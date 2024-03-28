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
    public class AddressRepository : EfEntityRepository<Address, OrderContext>, IAddressRepository
    {
        public AddressRepository(OrderContext context) : base(context)
        {
        }
    }
}
