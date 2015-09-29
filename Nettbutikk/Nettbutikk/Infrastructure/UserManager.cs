using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Nettbutikk.DAL;
using Nettbutikk.Models;
using System;

namespace Nettbutikk.Infrastructure
{
    public class UserManager : UserManager<User, Guid>
    {
        public UserManager(IUserStore<User, Guid> store)
            : base(store)
        {
        }

        /**
         * <summary>
         * Creates a new UserManager.
         * </summary>
         */
        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            // Gaaah! Long initialization is loong... Because UserStore<User> is not enough...
            return new UserManager(new UserStore<User, IdentityRole<Guid,
                IdentityUserRole<Guid>>, Guid, IdentityUserLogin<Guid>,
                IdentityUserRole<Guid>, IdentityUserClaim<Guid>>(context.Get<NettbutikkContext>()));
        }
    }
}