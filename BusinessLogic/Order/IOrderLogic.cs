using Nettbutikk.Model;

namespace Nettbutikk.BusinessLogic
{
    public interface IOrderLogic
    {
        int PlaceOrder(Order order);
        Order GetReciept(int orderId);
    }
}
