using Nettbutikk.Model;

namespace Nettbutikk.DataAccess
{
    public interface IOrderRepo
    {
        int PlaceOrder(OrderModel order);
        OrderModel GetReciept(int orderId);
    }
}
