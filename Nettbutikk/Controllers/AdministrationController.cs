using AutoMapper;
using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    [Route("Admin")]
    public class AdministrationController : BaseController
    {
        private IAdminLogic _adminBLL;

        public AdministrationController()
            : base()
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
                ViewBag.Customers = Mapper.Map<CustomerView>(_adminBLL.GetAllCustomers());
                ViewBag.Products = Services.Products.GetAll<ProductView>();

                List<OrderView> orderViewList = new List<OrderView>();

                foreach (var o in _adminBLL.GetAllOrders())
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
                            Id = l.ProductId,
                            Name = l.ProductName
                        };

                        order.Orderlines.Add(orderline);
                    }
                    orderViewList.Add(order);
                }
                
                ViewBag.Orders = orderViewList;

                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowCustomer(int CustomerId, string ReturnUrl)
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                var customerModel = _adminBLL.GetCustomer(CustomerId);

                var customerView = new CustomerView()
                {
                    Id = customerModel.CustomerId,
                    Email = customerModel.Email,
                    Firstname = customerModel.Firstname,
                    Lastname = customerModel.Lastname,
                    Address = customerModel.Address,
                    Zipcode = customerModel.Zipcode,
                    City = customerModel.City
                };

                //var orderModels = customerModel.Orders;
                //var orderViews = new List<OrderView>();

                //foreach (var o in orderModels)
                //{
                //    var order = new OrderView();
                //    order.Date = o.Date;
                //    order.OrderId = o.OrderId;
                //    order.Orderlines = new List<OrderlineView>();

                //    foreach (var l in o.Orderlines)
                //    {
                //        var orderline = new OrderlineView();
                //        orderline.Count = l.Count;
                //        orderline.OrderlineId = l.OrderlineId;
                //        orderline.Product = new ProductView()
                //        {
                //            Price = l.ProductPrice,
                //            ProductId = l.ProductId,
                //            ProductName = l.ProductName
                //        };

                //        order.Orderlines.Add(orderline);
                //    }
                //    orderViews.Add(order);
                //}

                ViewBag.Customer = customerView;
                //ViewBag.Orders = orderViews;
                ViewBag.ReturnUrl = ReturnUrl;

                return View("Administration_Customer");


            }
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult OrdersPartial(int CustomerId)
        {
            if ((Session["Admin"] == null ? false : (bool)Session["Admin"]))
            {
                IList<Order> orderModels;
                if (CustomerId > 0)
                    orderModels = _adminBLL.GetCustomer(CustomerId).Orders;
                else
                    orderModels = _adminBLL.GetAllOrders();

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
                            Id = l.ProductId,
                            Name = l.ProductName
                        };

                        order.Orderlines.Add(orderline);
                    }
                    orderViews.Add(order);
                }

                var productModels = _adminBLL.GetAllProducts();
                var productViews = new List<ProductView>();

                foreach (var productModel in productModels)
                {
                    var productview = new ProductView()
                    {
                        Id = productModel.Id,
                        Name = productModel.Name,
                        Description = productModel.Description,
                        Price = productModel.Price,
                        Stock = productModel.Stock,
                        ImageUrl = productModel.ImageUrl,
                        CategoryName = productModel.Category.Name
                    };
                    productViews.Add(productview);
                }
                
                ViewBag.Orders = orderViews;
                ViewBag.Products= productViews;


                return PartialView();
            }
            return RedirectToAction("Home", "Index");
        }



        [HttpPost]
        public bool UpdateCustomerInfo(CustomerView customerEdit)
        {
            var email = customerEdit.Email;

            var personUpdate = new Person()
            {
                Firstname = customerEdit.Firstname,
                Lastname = customerEdit.Lastname,
                Address = customerEdit.Address,
                Postal = new Postal
                {
                    Zipcode = customerEdit.Zipcode,
                    City = customerEdit.City
                }
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
            var orderlineModel = new Orderline()
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