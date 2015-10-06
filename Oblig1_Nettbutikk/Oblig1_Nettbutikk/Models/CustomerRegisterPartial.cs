using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oblig1_Nettbutikk.Models
{
    public class CustomerRegisterPartial
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }



    }
}