using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    [Route("Admin")]
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
                ViewBag.Customers = _adminBLL.GetAllCustomers()
                    .ConvertAll((customer) =>
                {
                    return new CustomerView()
                    {
                        CustomerId = customer.CustomerId,
                        Email = customer.Email,
                        Firstname = customer.Firstname,
                        Lastname = customer.Lastname,
                        Address = customer.Address,
                        Zipcode = customer.Zipcode,
                        City = customer.City
                    };
                });
                
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
                            ProductId = l.ProductId,
                            ProductName = l.ProductName
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