using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class CreateProduct : Product
    {
        public ICollection<CategoryView> Categories { get; set; }
    }
}