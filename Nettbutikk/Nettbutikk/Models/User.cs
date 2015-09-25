using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nettbutikk.Models
{
    public class User : IdentityUser
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get;
            set;
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

        [Required]
        [UIHint("EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get;
            set;
        }
    }
}