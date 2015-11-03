using Nettbutikk.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nettbutikk.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Zipcode {
            get { return Postal.Zipcode; }
            set { Postal.Zipcode = value; }
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string City
        {
            get { return Postal.City; }
        }
        
        public virtual Postal Postal { get; set; }
    }
}
