﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class Product
    {
        [Key]
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
        [UIHint("MultiLineText")]
        public string Description
        {
            get;
            set;
        }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price
        {
            get;
            set;
        }
        
        public Guid CategoryId
        {
            get;
            set;
        }

        public virtual Category Category
        {
            get;
            set;
        }
    }
}