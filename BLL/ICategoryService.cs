using Nettbutikk.Model;
using System.Collections.Generic;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  A product mapped entityservice.
     */
    public interface ICategoryService :
        IEntityService<Category>, IMappedEntityService<Category>
    {
        IEnumerable<Category> GetAll(IEnumerable<int> idList);
        Category GetById(int categoryId);
    }
}
