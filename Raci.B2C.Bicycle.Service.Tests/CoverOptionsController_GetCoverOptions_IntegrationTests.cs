using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raci.B2C.Bicycle.Service.Controllers;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;

namespace Raci.B2C.Bicycle.Service.Tests
{
    [TestClass]
    public class CoverOptionsController_GetCoverOptions_IntegrationTests
    {
        private IContextFactory _factory;

        [TestInitialize]
        public void Before()
        {
            _factory = new IntegrationTestDbContextFactory();

        }

        [TestCleanup]
        public void After()
        {
            ((IntegrationTestDbContextFactory)_factory).Cleanup();
        }

        [TestMethod]
        public async Task GetCoverOptions_Success()
        {
            CoverOptionsController controller = new CoverOptionsController(_factory);


            IList<CoverOptionDTO> options = ((await controller.GetCoverOptions()) as OkNegotiatedContentResult<IList<CoverOptionDTO>>).Content;

            Assert.IsNotNull(options);
        }
    }
}
