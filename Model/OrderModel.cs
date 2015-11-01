using System;
using System.Collections.Generic;

namespace Nettbutikk.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderlineModel> Orderlines { get; set; }
        public DateTime Date { get; set; }
    }
}
