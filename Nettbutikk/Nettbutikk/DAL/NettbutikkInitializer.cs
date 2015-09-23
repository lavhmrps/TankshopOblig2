using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Nettbutikk.DAL
{
    public class NettbutikkInitializer : CreateDatabaseIfNotExists<NettbutikkContext>
    {

    }
}