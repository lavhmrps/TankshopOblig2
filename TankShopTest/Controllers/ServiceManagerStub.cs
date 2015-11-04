using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers.Tests
{
    public class ServiceManagerStub : ServiceManager
    {
        public ServiceManagerStub()
        {

        }

        public void Inject(IService service)
        {
            if (service is IProductService)
            {
                Products = (IProductService)service;
            }
            if(service is ICategoryService)
            {
                Categories = (ICategoryService)service;
            }
            else if (service is IImageLogic)
            {
                Images = (IImageLogic)service;
            }
            else if (service is IAccountLogic)
            {
                Accounts = (IAccountLogic)service;
            }
        }
    }
}