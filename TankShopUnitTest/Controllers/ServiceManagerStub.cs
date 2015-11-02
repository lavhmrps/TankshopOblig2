using Nettbutikk.BusinessLogic;

namespace Nettbutikk.Controllers.Tests
{
    public class ServiceManagerStub : ServiceManager
    {
        public ServiceManagerStub()
        {

        }

        public void Configure(IService service)
        {
            if (service is IProductService)
            {
                Products = (IProductService)service;
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