using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.SharedLibrary.RabbitMQEvents
{
    public class ProductNameChangedEvent
    {
        public string ProductId { get; set; }
        public string UpdatedName { get; set; }

        public decimal UpdatedPrice { get; set; }
    }
}
