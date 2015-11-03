using Moq;
using System.Web.Mvc;

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

        protected ControllerContext CreateContextMock()
        {
            Mock<ControllerContext> mock = new Mock<ControllerContext>();
            return mock.Object;
        }
    }
}