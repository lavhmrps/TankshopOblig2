using Nettbutikk.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    // Postaladdress
    public class Postal
    {
        public Postal()
        {
            People = new List<Person>();
        }
        [Key]
        public string Zipcode { get; set; }
        public string City { get; set; }

        public virtual List<Person> People { get; set; }
    }



}
