using Oblig1_Nettbutikk.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1_Nettbutikk.Model;

namespace Oblig1_Nettbutikk.DAL
{
    public class OrderRepoStub : IOrderRepo
    {
        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderModel> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public double GetOrderSumTotal(int orderId)
        {
            throw new NotImplementedException();
        }

        public OrderModel GetReciept(int orderId)
        {
            throw new NotImplementedException();
        }

        public int PlaceOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrderline(OrderlineModel orderline)
        {
            throw new NotImplementedException();
        }
    }
}
