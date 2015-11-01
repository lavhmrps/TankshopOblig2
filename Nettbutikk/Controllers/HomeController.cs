using Nettbutikk.BusinessLogic;
using Nettbutikk.Models;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View(new HomeView {
                Categories = Services.Categories.GetAllMapped<CategoryView>(),
                Products = Services.Products.GetAllMapped<ProductView>(),
                LoggedIn = LoginStatus()
            });
        }

        public ActionResult Category(int CategoryId)
        {
            new HomeCategoryView()
            {
                Categories = Services.Categories.GetAll<CategoryView>(),
                Products = Services.Products
                    .GetMappedProductsByCategoryId<ProductView>(CategoryId),
                LoggedIn = LoginStatus(),
                Category = Services.Categories.GetById<CategoryView>(CategoryId)
            };

            return View("Index");
        }


        public bool LoginStatus()
        {
            bool LoggedIn = false;

            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool) Session["LoggedIn"];
            }

            return LoggedIn;
        }

    }
}