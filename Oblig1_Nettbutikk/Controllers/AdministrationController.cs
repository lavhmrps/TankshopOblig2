using Oblig1_Nettbutikk.BLL;
using Oblig1_Nettbutikk.Model;
using Oblig1_Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oblig1_Nettbutikk.Controllers
{
    public class AdministrationController : Controller
    {
        private IAdminLogic _adminBLL;

        public AdministrationController()
        {
            _adminBLL = new AdminBLL();
        }

        public AdministrationController(IAdminLogic stub)
        {
            _adminBLL = stub;
        }


        // GET: Administration
        public ActionResult Index()
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                var customerViewList = new List<CustomerView>();
                var customerModels = _adminBLL.GetAllCustomers();

                foreach (var Customer in customerModels)
                {
                    var customerView = new CustomerView()
                    {
                        CustomerId = Customer.CustomerId,
                        Email = Customer.Email,
                        Firstname = Customer.Firstname,
                        Lastname = Customer.Lastname,
                        Address = Customer.Address,
                        Zipcode = Customer.Zipcode,
                        City = Customer.City
                    };

                    customerViewList.Add(customerView);
                }

                List<OrderModel> orderModels = _adminBLL.GetAllOrders();
                List<OrderView> orderViewList = new List<OrderView>();

                foreach (var o in orderModels)
                {
                    var order = new OrderView();
                    order.Date = o.Date;
                    order.OrderId = o.OrderId;
                    order.Orderlines = new List<OrderlineView>();

                    foreach (var l in o.Orderlines)
                    {
                        var orderline = new OrderlineView();
                        orderline.Count = l.Count;
                        orderline.OrderlineId = l.OrderlineId;
                        orderline.Product = new ProductView()
                        {
                            Price = l.ProductPrice,
                            ProductId = l.ProductId,
                            ProductName = l.ProductName
                        };

                        order.Orderlines.Add(orderline);
                    }
                    orderViewList.Add(order);
                }

                ViewBag.Customers = customerViewList;
                ViewBag.Orders = orderViewList;

                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public bool UpdateCustomerInfo(CustomerView customerEdit)
        {
            var email = customerEdit.Email;

            var personUpdate = new PersonModel()
            {
                Firstname = customerEdit.Firstname,
                Lastname = customerEdit.Lastname,
                Address = customerEdit.Address,
                Zipcode = customerEdit.Zipcode,
                City = customerEdit.City
            };

            return _adminBLL.UpdatePerson(personUpdate, email);
        }

        [HttpPost]
        public bool DeleteCustomer(string email)
        {
            if (Session["Email"] != null)
            {
                if ((string)Session["Email"] != email)
                {
                    return _adminBLL.DeleteCustomer(email);
                }
            }
            return false;
        }

        [HttpPost]
        public bool UpdateOrderline(int OrderlineId, int ProductId, int Count)
        {
            var orderlineModel = new OrderlineModel()
            {
                Count = Count,
                OrderlineId = OrderlineId,
                ProductId = ProductId
            };

            if (_adminBLL.UpdateOrderline(orderlineModel))
            {
                return true;
            }
            return false;
        }

        public double GetOrderSumTotal(int OrderId)
        {
            return _adminBLL.GetOrderSumTotal(OrderId);

        }

        [HttpPost]
        public bool DeleteOrder(int OrderId)
        {
            return _adminBLL.DeleteOrder(OrderId);
        }
    }

}