using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Nettbutikk.Models
{
    public class Category
    {
        [Key]
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

        [ForeignKey("ParentCategory")]
        public int? ParentCategory
        {
            get;
            set;
        }
    }
}