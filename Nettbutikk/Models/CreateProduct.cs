using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class CreateProduct
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}