﻿using Nettbutikk.Models;
using System.Web.Mvc;
using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base()
        {

        }

        public HomeController(ServiceManager services)
            : base(services)
        {
        }

        public ActionResult Index()
        {
            return View(new HomeView {
                Categories = Services.Categories.GetAll<CategoryView>(),
                Products = Services.Products.GetAll<ProductView>(),
                LoggedIn = LoginStatus()
            });
        }

        public ActionResult Category(int CategoryId)
        {
            return View("Index", new HomeCategoryView()
                {
                    Categories = Services.Categories.GetAll<CategoryView>(),
                    Products = Services.Products
                        .GetProductsByCategoryId<ProductView>(CategoryId),
                    LoggedIn = LoginStatus(),
                    Category = Services.Categories.GetById<CategoryView>(CategoryId)
                });
        }
    }
}