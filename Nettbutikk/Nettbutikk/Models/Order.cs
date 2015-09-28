using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    
    public partial class Order
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        
        public DateTime PlacementDateTime { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        [HiddenInput(DisplayValue = false)]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        
        [Required]
        public virtual Address ShippingAddress
        {
            get;
            set;
        }

        [Required]
        public virtual Address BillingAddress
        {
            get;
            set;
        }
        
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
