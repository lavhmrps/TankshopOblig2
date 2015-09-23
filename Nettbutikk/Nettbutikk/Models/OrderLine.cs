using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class OrderLine
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id
        {
            get;
            set;
        }

        [ForeignKey("OrderId")]
        [HiddenInput(DisplayValue = false)]
        public virtual Order Order
        {
            get;
            set;
        }

        [ForeignKey("ProductId")]
        [Display(Name = "Product")]
        public virtual Product Product
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Amount")]
        [Range(0, int.MaxValue, ErrorMessage = "Cannot add a negative amount of products.")]
        public int Amount
        {
            get;
            set;
        }
    }
}