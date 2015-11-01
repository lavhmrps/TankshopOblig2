using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class EditProduct
    {
        public IEnumerable<Category> Categories { get; internal set; }
    }
}