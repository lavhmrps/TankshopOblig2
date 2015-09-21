using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Order
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public OrderLine[] Lines {
            get;
            set;
        }


    }
}