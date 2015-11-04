using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nettbutikk.Model
{
    public class Customer : Person
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int CustomerId {
            get { return Id; } set { Id = value; } }
        public List<Order> Orders { get; set; }
    }

}
