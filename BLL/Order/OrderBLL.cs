using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using DAL.Customer;
using DAL.Order;
using DAL.Product;

namespace BLL.Order
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

        public OrderModel GetOrder(int OrderId)
        {
            return _repo.GetOrder(OrderId);
        }

        public List<OrderModel> GetOrders(int CustomerId)
        {
            return _repo.GetOrders(CustomerId);
        }

        public bool UpdateOrderline(OrderlineModel orderline)
        {
            return _repo.UpdateOrderline(orderline);
        }

        public bool UpdateOrderline(OrderlineModel orderlineModel, int adminId)
        {
            return _repo.UpdateOrderline(orderlineModel, adminId);
        }
    }
}
