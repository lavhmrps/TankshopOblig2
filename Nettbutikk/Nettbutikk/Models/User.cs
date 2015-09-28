using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.AspNet.Identity;

namespace Nettbutikk.Models
{
    public class User : IdentityUser
    {
        [Key]
        [Required]
        public new Guid Id
        {
            get
            {
                return Guid.Parse(base.Id);
            }
            set
            {
                base.Id = value.ToString();
            }
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        // This property might be better to move into Customer,
        // or do we need this for regular users?
        [Required]
        [UIHint("Tel")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone
        {
            get;
            set;
        }

        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string PasswordSalt { get; set; }
    }
}
