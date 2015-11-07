using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BLL
{
    public class CustomerBLL :ICustomerLogic
    {
        private ICustomerRepo _repo;
        private IAccountRepo _accountrepo;
        private IOrderRepo _orderrepo;
        private IProductRepo _productrepo;

        public CustomerBLL()
        {
            _repo = new CustomerRepo();
            _accountrepo = new AccountRepo();
            _orderrepo = new OrderRepo();
            _productrepo = new ProductRepo();
        }

        public CustomerBLL(ICustomerRepo stub)
        {
            _repo = stub;
            _accountrepo = new AccountRepoStub();
            _orderrepo = new OrderRepoStub();
            _productrepo = new ProductRepoStub();
        }

        public bool DeleteCustomer(string email)
        {
            //Person burde egentlig hentes fra _repo
            Person person = new TankshopDbContext().People.Find(email);

            if (person == null)
                return false;

            if (!_accountrepo.AddOldPerson(person.Email, person.Firstname,
                person.Lastname, person.Address, person.Zipcode, 1))//Get admin id from session
                return false;

            return _repo.DeleteCustomer(email);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public bool UpdatePerson(PersonModel personUpdate, string email)
        {

            //Person burde egentlig hentes fra _repo
            Person person = new TankshopDbContext().People.Find(email);

            if (person == null)
                return false;

            if (!_accountrepo.AddOldPerson(email, personUpdate.Firstname,
                personUpdate.Lastname, personUpdate.Address, personUpdate.Zipcode, 1))//Get admin id from session
                return false;


            return _accountrepo.UpdatePerson(personUpdate, email);
        }

        //public List<OrderModel> GetAllOrders()
        //{
        //    return _orderrepo.GetAllOrders();
        //}

        //public bool UpdateOrderline(OrderlineModel orderline)
        //{
        //    return _orderrepo.UpdateOrderline(orderline);
        //}

        //public double GetOrderSumTotal(int orderId)
        //{
        //    return _orderrepo.GetOrderSumTotal(orderId);
        //}

        //public bool DeleteOrder(int orderId)
        //{
        //    return _orderrepo.DeleteOrder(orderId);
        //}

        public CustomerModel GetCustomer(int customerId)
        {
            return _repo.GetCustomer(customerId);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productrepo.GetAllProducts();
        }
    }
}
