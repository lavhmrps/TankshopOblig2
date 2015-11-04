using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk.Models
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public List<OrderlineView> Orderlines { get; set; }
    }

    public class OrderlineView
    {
        public int OrderlineId { get; set; }
        public ProductView Product{ get; set; }
        public int Count { get; set; }
    }
}