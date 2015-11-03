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
        private IProductService _productrepo;

        public AdminBLL()
        {
            _repo = new AdminRepo();
            _accountrepo = new AccountRepo();
            _orderrepo = new OrderRepo();
            _productrepo = new ProductService();
        }

        public bool DeleteCustomer(string email)
        {
            return _repo.DeleteCustomer(email);
        }

        public IList<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public bool UpdatePerson(Person personUpdate, string email)
        {
            return _accountrepo.UpdatePerson(personUpdate, email);
        }

        public IList<Order> GetAllOrders()
        {
            return _orderrepo.GetAllOrders();
        }

        public bool UpdateOrderline(Orderline orderline)
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

        public Customer GetCustomer(int customerId)
        {
            return _accountrepo.GetCustomer(customerId);
        }

        public ICollection<Product> GetAllProducts()
        {
            return _productrepo.GetAll<Product>();
        }
    }
}
