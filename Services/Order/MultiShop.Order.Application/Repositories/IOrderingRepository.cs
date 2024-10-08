﻿using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Repositories
{
   public interface IOrderingRepository:IRepository<Ordering>
    {
        Task<List<Ordering>> GetByUserIdAsync(string id);
    }
}
