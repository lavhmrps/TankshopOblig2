using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DataAccess
{
    public interface IOrderRepo
    {
        int PlaceOrder(OrderModel order);
        OrderModel GetReciept(int orderId);
    }
}
