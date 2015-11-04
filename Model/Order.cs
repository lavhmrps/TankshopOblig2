using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Order
    {
        public Order()
        {
            Orderlines = new List<Orderline>();
        }

        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public List<Orderline> Orderlines { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
