using System.Collections.Generic;

namespace Nettbutikk.Models
{
    class HomeView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
        public bool LoggedIn { get; set; }
        public IEnumerable<ProductView> Products { get; set; }
    }

    class HomeCategoryView : HomeView
    {
        public CategoryView Category;
    }
}