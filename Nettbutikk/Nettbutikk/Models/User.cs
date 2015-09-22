using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class User
    {
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

        [Required]
        public string Adress
        {
            get;
            set;
        }

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