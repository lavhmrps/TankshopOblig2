using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Customer : User
    {
        [Required]
        [ForeignKey("BillingAddressId")]
        public virtual Address BillingAddress
        {
            get;
            set;
        }
        
        [Required]
        [ForeignKey("ShippingAddressId")]
        public virtual Address PrimaryShippingAddress
        {
            get;
            set;
        }

        public virtual ICollection<Address> Addresses
        {
            get;
            set;
        }

        public virtual ICollection<Order> Orders
        {
            get;
            set;
        }
    }
}