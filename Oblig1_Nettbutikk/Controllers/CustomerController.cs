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
    public class CustomerController : Controller
    {
        private ICustomerLogic _customerBLL;

        public CustomerController()
        {
            _customerBLL = new CustomerBLL();
        }

        public CustomerController(ICustomerLogic stub)
        {
            _customerBLL = stub;
        }


        // GET: Customer administration
        public ActionResult Index()
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowCustomer(int CustomerId, string ReturnUrl)
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                var customerModel = _customerBLL.GetCustomer(CustomerId);

                var customerView = new CustomerView()
                {
                    CustomerId = customerModel.CustomerId,
                    Email = customerModel.Email,
                    Firstname = customerModel.Firstname,
                    Lastname = customerModel.Lastname,
                    Address = customerModel.Address,
                    Zipcode = customerModel.Zipcode,
                    City = customerModel.City
                };
                

                ViewBag.Customer = customerView;
                ViewBag.ReturnUrl = ReturnUrl;

                return View("Administration_Customer");

            }
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public PartialViewResult CustomerlistPartial()
        {
                var customerViewList = new List<CustomerView>();
                var customerModels = _customerBLL.GetAllCustomers();

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
                
                return PartialView(customerViewList);
        }

        [ChildActionOnly]
        public PartialViewResult OrdersPartial(int CustomerId)
        {
               List<OrderModel> orderModels;
                if (CustomerId > 0)
                    orderModels = _customerBLL.GetCustomer(CustomerId).Orders;
                else
                    orderModels = _customerBLL.GetAllOrders();

                var orderViews = new List<OrderView>();

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
                    orderViews.Add(order);
                }

                var productModels = _customerBLL.GetAllProducts();
                var productViews = new List<ProductView>();

                foreach (var productModel in productModels)
                {
                    var productview = new ProductView()
                    {
                        ProductId = productModel.ProductId,
                        ProductName = productModel.ProductName,
                        Description = productModel.Description,
                        Price = productModel.Price,
                        Stock = productModel.Stock,
                        ImageUrl = productModel.ImageUrl,
                        CategoryName = productModel.CategoryName
                    };
                    productViews.Add(productview);
                }

                string Title = CustomerId == 0 ? "Ordreadministrasjon - Alle ordre" : "Ordreadministrasjon - Kunde";
                
                ViewBag.Orders = orderViews;
                ViewBag.Products= productViews;
                ViewBag.Title = Title;


                return PartialView();
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

            return _customerBLL.UpdatePerson(personUpdate, email);
        }

        [HttpPost]
        public bool DeleteCustomer(string email)
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                if ((string)Session["Email"] != email)
                {
                    return _customerBLL.DeleteCustomer(email);
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

            if (_customerBLL.UpdateOrderline(orderlineModel))
            {
                return true;
            }
            return false;
        }

        public double GetOrderSumTotal(int OrderId)
        {
            return _customerBLL.GetOrderSumTotal(OrderId);

        }

        [HttpPost]
        public bool DeleteOrder(int OrderId)
        {
            return _customerBLL.DeleteOrder(OrderId);
        }
    }

}