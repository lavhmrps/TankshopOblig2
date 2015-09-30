using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class OrderLine
    {
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get;
            set;
        }

        [HiddenInput(DisplayValue = false)]
        public int Order
        {
            get;
            set;
        }

        [Display(Name = "Product")]
        public Product Product
        {
            get;
            set;
        }

        [Display(Name = "Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Cannot add a negative amount of products.")]
        public int Amount
        {
            get;
            set;
        }
    }
}