using System.Collections.Generic;

namespace Nettbutikk.Model
{
    public class CustomerModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
