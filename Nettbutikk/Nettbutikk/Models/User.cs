using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Nettbutikk.Models
{
    public class User : IdentityUser<Guid, IdentityUserLogin<Guid>, IdentityUserRole<Guid>, IdentityUserClaim<Guid>>, IUser<Guid>
    {
        private ICollection<Address> addresses;
        private ICollection<Order> orders;
        
        [Key]
        [Required]
        public string Name
        {
            get;
            set;
        }

        public string Phone { get; set; }

        [ForeignKey("PrimaryShippingAddress")]
        public Guid PrimaryShippingAddressId
        {
            get;
            set;
        }

        public virtual Address PrimaryShippingAddress { get; set; }

        [ForeignKey("PrimaryBillingAddress")]
        public Guid PrimaryBillingAddressId
        {
            get;
            set;
        }

        public virtual Address PrimaryBillingAddress { get; set; }
        
        public virtual ICollection<Address> Addresses
        {
            get { return addresses ?? (addresses = new HashSet<Address>()); }
            set { addresses = value; }
        }
        
        public virtual ICollection<Order> Orders
        {
            get { return orders ?? (orders = new HashSet<Order>()); }
            set { orders = value; }
        }
    }
}
