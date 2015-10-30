using Nettbutikk.BusinessLogic;
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
    }
}