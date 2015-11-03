using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class HomeView
    {
        public ICollection<CategoryView> Categories { get; set; }
        public bool LoggedIn { get; set; }
        public ICollection<ProductView> Products { get; set; }
    }

    public class HomeCategoryView : HomeView
    {
        public CategoryView Category;
    }
}