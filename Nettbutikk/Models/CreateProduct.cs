using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class CreateProduct
    {
        public ICollection<CategoryView> Categories { get; set; }
    }
}