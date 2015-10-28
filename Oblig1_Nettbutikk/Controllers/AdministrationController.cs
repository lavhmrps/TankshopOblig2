using Nettbutikk.BusinessLogic;
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
                var customerViewList = new List<CustomerView>();
                var customerModels = _adminBLL.GetAllCustomers();

                foreach(var Customer in customerModels)
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


                ViewBag.Customers = customerViewList;

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}