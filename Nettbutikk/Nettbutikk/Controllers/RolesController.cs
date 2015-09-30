using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("auth/roles")]
    public class RolesController : BaseController
    {
        public async Task<ActionResult> GetRole(string id)
        {
            var role = await this.AppRoleManager.FindByAsync(id);
        }
    }
}