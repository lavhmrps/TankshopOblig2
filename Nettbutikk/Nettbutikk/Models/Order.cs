using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get;
            set;
        }

        [HiddenInput(DisplayValue = false)]
        public Customer Customer
        {
            get;
            set;
        }

        [HiddenInput(DisplayValue = false)]
        [UIHint("DateTime")]
        [DataType(DataType.DateTime)]
        public DateTime Date
        {
            get;
            set;
        }

        [Display(Name="Cart contents")]
        [UIHint("Collection")]
        public OrderLine[] Lines {
            get;
            set;
        }
    }
}