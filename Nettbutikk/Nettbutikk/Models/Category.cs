using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class Category
    {
        [HiddenInput(DisplayValue = false)]
        public int Id {
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
        public string Description
        {
            get;
            set;
        }

        public int? ParentCategory
        {
            get;
            set;
        }
    }
}