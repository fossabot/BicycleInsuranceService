using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raci.B2C.Bicycle.Service.Controllers;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;
using Raci.B2C.Bicycle.Service.Services;

namespace Raci.B2C.Bicycle.Service.Tests
{
    /// <summary>
    /// Summary description for PolicyController_GetPolicy_IntegrationTests
    /// </summary>
    [TestClass]
    public class PolicyController_GetPolicy_IntegrationTests
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

        //public async Task GetPolicy_CreatedPolicy()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);

        //    Assert.IsNotNull(loaded);
        //    Assert.AreEqual(dto.Id, loaded.Id);
        //    Assert.IsTrue(loaded.IsNew);

        //    Assert.IsNull(loaded.Contact);
        //    Assert.IsNull(loaded.Detail);
        //    Assert.IsNull(loaded.Option);
        //    Assert.IsNull(loaded.Payment);
        //}

        //[TestMethod]
        //public async Task GetPolicy_DetailsAdded()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await SetTestDetails(controller, dto);

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);
        //    Assert.IsTrue(loaded.IsNew);

        //    Assert.IsNotNull(loaded.Detail);

        //    Assert.AreEqual("Make", loaded.Detail.Make);
        //    Assert.AreEqual("Model", loaded.Detail.Model);
        //    Assert.AreEqual("Type", loaded.Detail.Type);
        //    Assert.AreEqual("Year", loaded.Detail.Year);
        //}


        //[TestMethod]
        //public async Task GetPolicy_BasicContactDetailsAdded()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await SetTestDetails(controller, dto);

        //    await SetTestBasicContactDetails(controller, dto);

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);

        //    Assert.IsTrue(loaded.IsNew);

        //    Assert.IsNotNull(loaded.Detail);
        //    Assert.IsNotNull(loaded.Contact);

        //    Assert.AreEqual("dimmy@dimmy.com", loaded.Contact.EmailAddress);
        //}

        //[TestMethod]
        //public async Task GetPolicy_ProductOptionSelected()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await SetTestDetails(controller, dto);
        //    await SetTestBasicContactDetails(controller, dto);
        //    await SetTestPolicyOption(controller, dto);

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);

        //    Assert.IsTrue(loaded.IsQuote);

        //    Assert.IsNotNull(loaded.Detail);
        //    Assert.IsNotNull(loaded.Contact);
        //    Assert.IsNotNull(loaded.Option);

        //    Assert.AreEqual("Turbo Insurance", loaded.Option.Description);
        //    Assert.AreEqual("Turbo", loaded.Option.Code);
        //    Assert.AreEqual((decimal)250.0, loaded.Option.AnnualPremium);
        //    Assert.AreEqual("2501-5000", loaded.Option.AgreedValue);
        //    Assert.AreEqual((decimal)250.0, loaded.Option.Excess);
        //}


        //[TestMethod]
        //public async Task GetPolicy_FullContactDetailsEntered()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await SetTestDetails(controller, dto);

        //    await SetTestBasicContactDetails(controller, dto);

        //    await SetTestPolicyOption(controller, dto);

        //    await SetTestFullContactDetails(controller, dto);

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);

        //    Assert.IsTrue(loaded.IsQuote);

        //    Assert.IsNotNull(loaded.Detail);
        //    Assert.IsNotNull(loaded.Contact);
        //    Assert.IsNotNull(loaded.Option);

        //    Assert.AreEqual(IntegrationTestUtils.BIRTHDAY, loaded.Contact.DateOfBirth);
        //    Assert.AreEqual("Dimmy", loaded.Contact.FirstName);
        //    Assert.AreEqual("Dimmington", loaded.Contact.LastName);
        //    Assert.AreEqual("000", loaded.Contact.PhoneNumber);

        //    Assert.IsNotNull(loaded.Contact.Address);
        //    Assert.AreEqual("AddressLine1", loaded.Contact.Address.AddressLine1);
        //    Assert.AreEqual("PostCode", loaded.Contact.Address.PostCode);
        //    Assert.AreEqual("Suburb", loaded.Contact.Address.Suburb);
        //}

        //[TestMethod]
        //public async Task GetPolicy_PolicyPaid()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await SetTestDetails(controller, dto);

        //    await SetTestBasicContactDetails(controller, dto);

        //    await SetTestPolicyOption(controller, dto);

        //    await SetTestFullContactDetails(controller, dto);

        //    await controller.MarkAsPaid(dto.Id, "transactionId");

        //    PolicyDTO loaded = await controller.GetPolicy(dto.Id);

        //    Assert.IsNotNull(loaded.Detail);
        //    Assert.IsNotNull(loaded.Contact);
        //    Assert.IsNotNull(loaded.Option);
        //    Assert.IsNotNull(loaded.Payment);

        //    Assert.AreEqual("transactionId", loaded.Payment.TransactionId);

        //    Assert.IsTrue(loaded.IsPolicy);
        //}

        //private static async Task SetTestDetails(PolicyService controller, PolicyDTO dto)
        //{
        //    await controller.SetDetails(dto.Id, new BicyclePolicyDetailDTO()
        //    {
        //        Make = "Make",
        //        Model = "Model",
        //        Type = "Type",
        //        Year = "Year"
        //    });
        //}

        //private static async Task SetTestBasicContactDetails(PolicyService controller, PolicyDTO dto)
        //{
        //    await controller.SetContact(dto.Id, new PolicyContactDTO()
        //    {
        //        EmailAddress = "dimmy@dimmy.com",
        //    });
        //}

        //private async Task SetTestPolicyOption(PolicyService controller, PolicyDTO dto)
        //{
        //    await controller.SetPolicyOption(dto.Id, new PolicyOptionDTO()
        //    {
        //        AgreedValue = "2501-5000",
        //        AnnualPremium = 250,
        //        Code = "Turbo",
        //        Description = "Turbo Insurance",
        //        Excess = 250
                
        //    });
        //}

        //private async Task SetTestFullContactDetails(PolicyService controller, PolicyDTO dto)
        //{
        //    await controller.SetContact(dto.Id, new PolicyContactDTO()
        //    {
        //        Address = new AddressDTO()
        //        {
        //            AddressLine1 = "AddressLine1",
        //            PostCode = "PostCode",
        //            Suburb = "Suburb"
        //        },
        //        EmailAddress = "dimmy@dimmy.com",
        //        DateOfBirth = IntegrationTestUtils.BIRTHDAY,
        //        FirstName = "Dimmy",
        //        LastName = "Dimmington",
        //        PhoneNumber = "000"
        //    });
        //}
    }
}
