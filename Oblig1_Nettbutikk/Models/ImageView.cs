using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class ImageView
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}