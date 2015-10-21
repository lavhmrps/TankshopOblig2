using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.Model
{
    class OrderlineModel
    {
        public int OrderlineId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public ProductModel Product { get; set; }
        public OrderModel Order { get; set; }
    }
}
