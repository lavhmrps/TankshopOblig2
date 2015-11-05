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
        private IProductRepo _productrepo;
        private ICustomerRepo _customerrepo;

        public OrderBLL()
        {
            _repo = new OrderRepo();
            _productrepo = new ProductRepo();
            _customerrepo = new CustomerRepo();
        }

        public OrderBLL(IOrderRepo stub)
        {
            _repo = stub;
            _productrepo = new ProductRepoStub();
            _customerrepo = new CustomerRepoStub();
        }

        public OrderModel GetReciept(int orderId)
        {
            return _repo.GetReciept(orderId);
        }

        public int PlaceOrder(OrderModel order)
        {
            return _repo.PlaceOrder(order);
        }
        public List<OrderModel> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public bool UpdateOrderline(OrderlineModel orderline)
        {
            return _repo.UpdateOrderline(orderline);
        }

        public double GetOrderSumTotal(int orderId)
        {
            return _repo.GetOrderSumTotal(orderId);
        }

        public bool DeleteOrder(int orderId)
        {
            return _repo.DeleteOrder(orderId);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _productrepo.GetAllProducts();
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return _customerrepo.GetCustomer(customerId);
        }
    }
}
