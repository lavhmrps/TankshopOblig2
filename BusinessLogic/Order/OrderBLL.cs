using Nettbutikk.DataAccess;
using Nettbutikk.Model;

namespace Nettbutikk.BusinessLogic
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

        public Order GetReciept(int orderId)
        {
            return _repo.GetReciept(orderId);
        }

        public int PlaceOrder(Order order)
        {
            return _repo.PlaceOrder(order);
        }
    }
}
