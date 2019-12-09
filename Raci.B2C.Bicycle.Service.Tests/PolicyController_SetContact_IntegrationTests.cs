using System;
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
    public class PolicyController_SetContact_IntegrationTests
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
        //public async Task SetContact_Success()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetContact(dto.Id, IntegrationTestUtils.CreateContact());

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy policy = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);
        //        PolicyContact loaded = policy.Contact;

        //        Assert.IsNotNull(loaded);

        //        Assert.AreEqual("dimmy@dimmy.com", loaded.EmailAddress);
        //        Assert.AreEqual("Dimmy", loaded.FirstName);
        //        Assert.AreEqual("Dimmington", loaded.LastName);
        //        Assert.AreEqual("000", loaded.PhoneNumber);
        //        Assert.AreEqual(IntegrationTestUtils.BIRTHDAY, loaded.DateOfBirth);
        //        Assert.IsNotNull(loaded.CreatedAt);


        //        Assert.IsNotNull(loaded.Address);

        //        Assert.AreEqual("PostCode", loaded.Address.PostCode);
        //        Assert.AreEqual("AddressLine1", loaded.Address.AddressLine1);
        //        Assert.AreEqual("Suburb", loaded.Address.Suburb);
        //        Assert.IsNotNull(loaded.Address.CreatedAt);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}



        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task SetContact_PolicyIsInPolicyState_ShouldReturnBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller, PolicyState.Policy);

        //    await controller.SetContact(dto.Id, IntegrationTestUtils.CreateContact());
        //}

        ////[TestMethod]
        ////[ExpectedException(typeof(NotFoundException))]

        ////public async Task SetContact_PolicyDoesntExist_ShouldReturnNotFound()
        ////{
        ////    PolicyService controller = new PolicyService(_factory);

        ////    await controller.SetContact(long.MaxValue, IntegrationTestUtils.CreateContact());
        ////}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]

        //public async Task SetContact_NoContactProvided_ShouldReturnBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetContact(dto.Id, null);
        //}

        //[TestMethod]
        //public async Task SetContact_Update()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.SetContact(dto.Id, IntegrationTestUtils.CreateContact());

        //    PolicyContactDTO newContact = IntegrationTestUtils.CreateContact();
        //    newContact.FirstName = "Update";
        //    newContact.LastName = "Test";

        //    await controller.SetContact(dto.Id, newContact);

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy policy = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);
        //        PolicyContact loaded = policy.Contact;

        //        Assert.AreEqual("Update", loaded.FirstName);
        //        Assert.AreEqual("Test", loaded.LastName);

        //        Assert.AreEqual(1, ctx.Policies.Count());

        //    }
        //}

    }
}
