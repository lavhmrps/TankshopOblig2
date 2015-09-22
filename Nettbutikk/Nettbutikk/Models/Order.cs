using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class Order
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get;
            set;
        }
        
        [ForeignKey("CustomerId")]
        [HiddenInput(DisplayValue = false)]
        public Customer Customer
        {
            get;
            set;
        }

        [HiddenInput(DisplayValue = false)]
        // These validations aren't needed, methinks;
        // They're just for internal use and record-keeping.
        // But they might be useful in the case the value is to be displayed.
        // [UIHint("DateTime")]
        // [DataType(DataType.DateTime)]
        public DateTime PlacedDateTime
        {
            get;
            set;
        }

        [Display(Name="Cart contents")]
        [UIHint("Collection")]
        public virtual ICollection<OrderLine> Lines
        {
            get;
            set;
        }

        [Required]
        public Address ShippingAddress
        {
            get;
            set;
        }
    }
}