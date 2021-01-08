using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkovdePizzaApi.Models
{
    public class PaymentData
    {
        public long Cost { get; set; }
        public string OrderNumber { get; set; }
    }
}
