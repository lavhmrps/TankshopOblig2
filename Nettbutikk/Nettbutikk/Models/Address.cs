using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Models
{
    public class Address
    {
        [Required]
        public string Street
        {
            get;
            set;
        }

        [Required]
        public string HouseNumber
        {
            get;
            set;
        }

        [Required]
        public string ZipCode
        {
            get;
            set;
        }

        [Required]
        public string City
        {
            get;
            set;
        }
        
        public string State
        {
            get;
            set;
        }


        public string Country
        {
            get;
            set;
        }
    }
}