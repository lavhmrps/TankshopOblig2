using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.Model
{
    class OrderModel
    {
        public int OrderId { get; set; }
        public string PersonId { get; set; }
        public DateTime Date { get; set; }
        public PersonModel Person { get; set; }
        public List<OrderlineModel> Orderlines { get; set; }
    }
}
