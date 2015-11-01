using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class HomeView
    {
        public IEnumerable<CategoryView> Categories { get; set; }
        public bool LoggedIn { get; set; }
        public IEnumerable<ProductView> Products { get; set; }
    }

    public class HomeCategoryView : HomeView
    {
        public CategoryView Category;
    }
}