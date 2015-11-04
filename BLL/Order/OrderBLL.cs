using Oblig1_Nettbutikk.DAL;
using Oblig1_Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1_Nettbutikk.BLL
{
    public class OrderBLL : IOrderLogic
    {
        private IOrderRepo _repo;

        public OrderBLL()
        {
            _repo = new OrderRepo();
        }

        public OrderBLL(IOrderRepo stub)
        {
            _repo = stub;
        }

        public OrderModel GetReciept(int orderId)
        {
            return _repo.GetReciept(orderId);
        }

        public int PlaceOrder(OrderModel order)
        {
            return _repo.PlaceOrder(order);
        }
    }
}
