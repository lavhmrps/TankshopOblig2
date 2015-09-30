﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nettbutikk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    
    public partial class Order
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        
        public DateTime PlacementDateTime { get; set; }

        [ForeignKey("CustomerId")]
        [HiddenInput(DisplayValue = false)]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        
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
    }
}
