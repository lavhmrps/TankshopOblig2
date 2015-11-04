using System.Collections.Generic;
using Nettbutikk.Model;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  A product mapped entityservice.
     */
    public interface ICategoryService :
        IEntityService<Category>, IMappedEntityService<Category>
    {
        ICollection<Category> GetAll(ICollection<int> idList);
    }

}