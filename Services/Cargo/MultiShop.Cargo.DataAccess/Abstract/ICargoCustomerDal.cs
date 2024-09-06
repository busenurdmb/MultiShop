﻿using MultiShop.Cargo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Abstract
{
    public interface ICargoCustomerDal:IEntityRepository<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    }
}
