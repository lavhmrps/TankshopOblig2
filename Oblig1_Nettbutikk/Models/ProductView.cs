using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk.Models
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
    }
}