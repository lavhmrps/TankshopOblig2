using Nettbutikk.DataAccess;
using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    public class AdminBLL : IAdminLogic
    {
        private AdminRepo _repo;
        private IAccountRepo _accountrepo;
        private IOrderRepo _orderrepo;

        public AdminBLL()
        {
            _repo = new AdminRepo();
            _accountrepo = new AccountRepo();
            _orderrepo = new OrderRepo();
        }

        public bool DeleteCustomer(string email)
        {
            return _repo.DeleteCustomer(email);
        }

        public IList<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public bool UpdatePerson(PersonModel personUpdate, string email)
        {
            return _accountrepo.UpdatePerson(personUpdate, email);
        }

        public IList<OrderModel> GetAllOrders()
        {
            return _orderrepo.GetAllOrders();
        }

        public bool UpdateOrderline(OrderlineModel orderline)
        {
            return _orderrepo.UpdateOrderline(orderline);
        }

        public double GetOrderSumTotal(int orderId)
        {
            return _orderrepo.GetOrderSumTotal(orderId);
        }

        public bool DeleteOrder(int orderId)
        {
            return _orderrepo.DeleteOrder(orderId);
        }
    }
}
