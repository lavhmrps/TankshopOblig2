using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.AspNet.Identity;

namespace Nettbutikk.Models
{
    public class User : IdentityUser<Guid, IdentityUserLogin<Guid>, IdentityUserRole<Guid>, IdentityUserClaim<Guid>>, IUser<Guid>
    {
        [Required]
        public string Name
        {
            get;
            set;
        }
    }
}
