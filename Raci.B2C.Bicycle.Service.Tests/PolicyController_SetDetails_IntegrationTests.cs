using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raci.B2C.Bicycle.Service.Controllers;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;
using Raci.B2C.Bicycle.Service.Services;

namespace Raci.B2C.Bicycle.Service.Tests
{
    [TestClass]
    public class PolicyController_SetDetails_IntegrationTests
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
        //public async Task SetDetails_Success()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);


        //    await controller.SetDetails(dto.Id, new BicyclePolicyDetailDTO()
        //    {
        //        Make = "Make",
        //        Model = "Model",
        //        Type = "Type",
        //        Year = "Year"
        //    });


        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);
        //        BicyclePolicyDetail detail = pol.Detail;

        //        Assert.IsNotNull(detail);

        //        Assert.AreEqual("Make", detail.Make);
        //        Assert.AreEqual("Model", detail.Model);
        //        Assert.AreEqual("Type", detail.Type);
        //        Assert.AreEqual("Year", detail.Year);
        //        Assert.IsNotNull(detail.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}

        ////[TestMethod]
        ////[ExpectedException(typeof(NotFoundException))]

        ////public async Task SetDetails_PolicyDoesntExist_ReturnsNotFound()
        ////{
        ////    PolicyService controller = new PolicyService(_factory);

        ////    await controller.SetDetails(long.MaxValue, new BicyclePolicyDetailDTO()
        ////    {
        ////        Make = "Make",
        ////        Model = "Model",
        ////        Type = "Type",
        ////        Year = "Year"
        ////    });
        ////}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task SetDetails_NoDetailsProvided_ReturnsBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetDetails(dto.Id, null);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]

        //public async Task SetDetails_QuoteAlreadyConvertedToPolicy_ReturnsBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller, PolicyState.Policy);


        //    await controller.SetDetails(dto.Id, CreateDetailsDTO());
        //}

        //[TestMethod]
        //public async Task SetDetails_Update()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);


        //    await controller.SetDetails(dto.Id, CreateDetailsDTO());

        //    BicyclePolicyDetailDTO newDetails = CreateDetailsDTO();
        //    newDetails.Make = "Update";
        //    newDetails.Model = "Test";
        //    newDetails.Type = "Update";
        //    newDetails.Year = "Test";

        //    await controller.SetDetails(dto.Id, newDetails);

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);
        //        BicyclePolicyDetail detail = pol.Detail;

        //        Assert.IsNotNull(detail);

        //        Assert.AreEqual("Update", detail.Make);
        //        Assert.AreEqual("Test", detail.Model);
        //        Assert.AreEqual("Update", detail.Type);
        //        Assert.AreEqual("Test", detail.Year);
        //        Assert.IsNotNull(detail.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}

        //private static BicyclePolicyDetailDTO CreateDetailsDTO()
        //{
        //    return new BicyclePolicyDetailDTO()
        //    {
        //        Make = "Make",
        //        Model = "Model",
        //        Type = "Type",
        //        Year = "Year"
        //    };
        //}
    }
}
