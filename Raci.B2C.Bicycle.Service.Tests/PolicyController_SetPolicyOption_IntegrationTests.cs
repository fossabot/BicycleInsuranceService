using System;
using System.Collections.Generic;
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
    public class PolicyController_SetPolicyOption_IntegrationTests
    {
        //private IContextFactory _factory;
        //private IList<CoverOptionDTO> _coverOptions;

        //[TestInitialize]
        //public void Before()
        //{
        //    _factory = new IntegrationTestDbContextFactory();

        //    Task<IList<CoverOptionDTO>> task = IntegrationTestUtils.CreateCoverOptions(_factory);
        //    task.Wait();

        //    _coverOptions = task.Result;
        //}

        //[TestCleanup]
        //public void After()
        //{
        //    ((IntegrationTestDbContextFactory)_factory).Cleanup();
        //}

        //[TestMethod]
        //public async Task SetPolicyOption_Success()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetPolicyOption(dto.Id, new PolicyOptionDTO()
        //    {
        //        AgreedValue = "2501-5000",
        //        AnnualPremium = 250,
        //        Code = "Turbo",
        //        Description = "Turbo",
        //        Excess = 250
        //    });

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);

        //        Assert.IsNotNull(pol.Option);

        //        Assert.AreEqual("Turbo", pol.Option.Description);
        //        Assert.AreEqual("Turbo", pol.Option.Code);
        //        Assert.AreEqual((decimal)250.0, pol.Option.AnnualPremium);
        //        Assert.AreEqual((decimal)250.0, pol.Option.Excess);
        //        Assert.IsNotNull(pol.Option.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task SetPolicyOption_PolicyIsInPolicyState_ShouldReturnBadResult()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller, PolicyState.Policy);

        //    await controller.SetPolicyOption(dto.Id, new PolicyOptionDTO()
        //    {
        //        AgreedValue = "2501-5000",
        //        AnnualPremium = 250,
        //        Code = "Turbo",
        //        Description = "Turbo",
        //        Excess = 250
        //    });
        //}

        ////[TestMethod]
        ////[ExpectedException(typeof(NotFoundException))]

        ////public async Task SetPolicyOption_PolicyDoesNotExist_ShouldReturnNotFound()
        ////{
        ////    PolicyService controller = new PolicyService(_factory);

        ////    await controller.SetPolicyOption(long.MaxValue, new PolicyOptionDTO()
        ////    {
        ////        AgreedValue = "2501-5000",
        ////        AnnualPremium = 250,
        ////        Code = "Turbo",
        ////        Description = "Turbo",
        ////        Excess = 250
        ////    });
        ////}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]

        //public async Task SetPolicyOption_NoCoverOptionSpecified_ShouldReturnBadResult()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetPolicyOption(dto.Id, null);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task SetPolicyOption_UnknownCoverOptionSpecified_ShouldReturnBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetPolicyOption(dto.Id, null);
        //}

        //[TestMethod]
        //public async Task SetPolicyOption_Update()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetPolicyOption(dto.Id, new PolicyOptionDTO()
        //    {
        //        AgreedValue = "2501-5000",
        //        AnnualPremium = 250,
        //        Code = "Turbo",
        //        Description = "Turbo",
        //        Excess = 250
        //    });

        //    await controller.SetPolicyOption(dto.Id, new PolicyOptionDTO()
        //    {
        //        AgreedValue = "5",
        //        AnnualPremium = 2,
        //        Code = "Changed",
        //        Description = "Changed",
        //        Excess = 2
        //    });

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);

        //        Assert.IsNotNull(pol.Option);

        //        Assert.AreEqual("Changed", pol.Option.Description);
        //        Assert.AreEqual("Changed", pol.Option.Code);
        //        Assert.AreEqual((decimal)2, pol.Option.AnnualPremium);
        //        Assert.AreEqual((decimal)2, pol.Option.Excess);
        //        Assert.AreEqual("5", pol.Option.AgreedValue);
        //        Assert.IsNotNull(pol.Option.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}
    }
}
