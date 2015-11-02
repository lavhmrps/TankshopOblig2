using System;

namespace Nettbutikk.Controllers.Tests
{
    public class ControllerTestsBase
    {
        protected ServiceManagerStub Services { get; private set; }

        public void Setup()
        {
            Services = new ServiceManagerStub();
        }

        internal void Teardown()
        {
            Services.Dispose();
            Services = null;
        }
    }
}