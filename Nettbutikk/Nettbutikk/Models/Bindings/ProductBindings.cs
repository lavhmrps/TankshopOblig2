using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Models.Bindings
{
    public class CreateProduct
    {
        [Required]
        public string Name;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number.")]
        public double Price;

        [Required]
        public string Description;

        [Required]
        public Guid CategoryId;

        public ICollection<Category> Categories;
    }

    public class EditProduct
    {
        [Required]
        public string Name;
        public double Price;
        public string Description;
        public Guid CategoryId;
    }
}