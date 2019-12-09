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
    public class PolicyController_MarkAsPaid_IntegrationTests
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
        //public async Task MarkAsPaid_Success()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller);

        //    await controller.MarkAsPaid(dto.Id, "transactionId");

        //    using (InsuranceDbContext ctx = _factory.CreateContext())
        //    {
        //        Policy pol = ctx.Policies.FirstOrDefault(x => x.Id == dto.Id);

        //        PaymentDetail payment = pol.Payment;
        //        Assert.IsNotNull(payment);

        //        Assert.AreEqual("transactionId", payment.TransactionId);
        //        Assert.IsNotNull(payment.CreatedAt);
        //        Assert.AreEqual(PolicyState.Policy, pol.State);
        //        Assert.IsNotNull(pol.PolicyNumber);

        //        Assert.AreEqual(1, ctx.Policies.Count());
        //    }
        //}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task MarkAsPaid_PolicyIsInPolicyState_ShouldReturnBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller, PolicyState.Policy);

        //    await controller.MarkAsPaid(dto.Id, "transactionId");
        //}

        ////[TestMethod]
        ////[ExpectedException(typeof(NotFoundException))]

        ////public async Task MarkAsPaid_PolicyDoesNotExist_ShouldReturnNotFound()
        ////{
        ////    PolicyService controller = new PolicyService(_factory);

        ////    await controller.MarkAsPaid(long.MaxValue, "transactionId");
        ////}

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]

        //public async Task MarkAsPaid_NoTransactionIdProvided_ShouldReturnBadRequest()
        //{
        //    PolicyService controller = new PolicyService(_factory);
        //    PolicyDTO dto = await IntegrationTestUtils.CreatePolicy(_factory, controller, PolicyState.Policy);

        //    await controller.MarkAsPaid(dto.Id, null);
        //}
    }
}
