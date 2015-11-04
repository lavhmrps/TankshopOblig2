using Nettbutikk.DataAccess;
using Nettbutikk.Model;
using System;

namespace Nettbutikk.BusinessLogic
{
    /***
     *  A central service/BLL layer manager.
     */
    public class ServiceManager : IDisposable
    {
        /***
         *  The internal database context/connection to be used by repositories.
         */
        protected TankshopDbContext context;

        public ICategoryService Categories { get; protected set; }
        public IProductService Products { get; protected set; }
        public IImageLogic Images { get; protected set; }
        public IAccountLogic Accounts { get; protected set; }

        public ServiceManager()
        {
            context = new TankshopDbContext();
            Categories = new CategoryService(new CategoryRepository(context));
            Products = new ProductService(new ProductRepository(context));
            Images = new ImageBLL();
            Accounts = new AccountBLL();
        }

        public ServiceManager(params IService[] services)
        {
            foreach(var service in services)
            {
                if(service is IProductService)
                {
                    Products = (IProductService) service;
                }
                else if(service is IImageLogic)
                {
                    Images = (IImageLogic) service;
                }
                else if(service is IAccountRepository)
                {
                    Accounts = (IAccountLogic) service;
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Categories.Dispose();
                    Categories = null;
                    Products.Dispose();
                    Products = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ServiceManager() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
