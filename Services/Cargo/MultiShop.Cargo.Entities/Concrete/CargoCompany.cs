using MultiShop.Cargo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Entities.Concrete
{
    public class CargoCompany:IEntity
    {
        public int CargoCompanyId { get; set; }
        public string CargoCompanyName { get; set; }
    }
}
