using Nettbutikk.Model;

namespace Nettbutikk.BusinessLogic
{
    public interface IOrderLogic
    {
        int PlaceOrder(OrderModel order);
        OrderModel GetReciept(int orderId);
    }
}
