using Nettbutikk.BusinessLogic;
using Nettbutikk.Model;
using Nettbutikk.Models;
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
                ;

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
                else
                {
                    if(_adminBLL.DeleteCustomer(email))
                    {
                        Session.Abandon();
                        RedirectToAction("Index", "Home");
                    }
                }
            }
            return false;
        }
    }
}