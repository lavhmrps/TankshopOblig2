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
        public List<Orderline> Orderlines { get; set; }
    }
}