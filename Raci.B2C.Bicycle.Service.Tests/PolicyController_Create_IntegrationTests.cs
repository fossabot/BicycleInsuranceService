using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raci.B2C.Bicycle.Service.Controllers;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Tests
{
    [TestClass]
    public class PolicyController_Create_IntegrationTests
    {
        //private IContextFactory _factory;

        //[TestInitialize]
        //public void Before()
        //{
        //    _factory = new IntegrationTestDbContextFactory();

        //}
        
        //[TestCleanup]
        //public void After()
        //{
        //    ((IntegrationTestDbContextFactory)_factory).Cleanup();
        //}
        

        //[TestMethod]
        //public async Task CreatePolicy_Success()
        //{
        //    PoliciesController controller = new PoliciesController(_factory);

        //    IHttpActionResult result = await controller.Create();


        //    OkNegotiatedContentResult<long> okResult = result as OkNegotiatedContentResult<long>;
        //    Assert.IsNotNull(okResult);

        //    long policyId = okResult.Content;

        //    Assert.IsTrue(policyId == 1);

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == policyId);

        //        Assert.IsNotNull(pol);
        //        Assert.IsFalse(pol.Id == 0);
        //        Assert.IsNotNull(pol.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());
        //    }
        //}
    }
}
