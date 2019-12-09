using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Raci.B2C.Bicycle.Service.Controllers;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;
using Raci.B2C.Bicycle.Service.Services;

namespace Raci.B2C.Bicycle.Service.Tests
{
    public class IntegrationTestUtils
    {
        public static readonly DateTime BIRTHDAY = new DateTime(1982, 6, 15);

        //public static async Task<PolicyDTO> CreatePolicy(IContextFactory factory, PolicyService controller, PolicyState state = PolicyState.New)
        //{
        //    long id = await controller.Create();

        //    if (state != PolicyState.New)
        //    {
        //        using (InsuranceDbContext ctx = factory.CreateContext())
        //        {
        //            ctx.Policies.FirstOrDefault(x => x.Id == id).State = state;
        //            await ctx.SaveChangesAsync();
        //        }
        //    }

        //    return await controller.GetPolicy(id);
        //}

        public static PolicyContactDTO CreateContact()
        {
            return new PolicyContactDTO()
            {
                Address = new AddressDTO()
                {
                    PostCode = "PostCode",
                    AddressLine1 = "AddressLine1",
                    Suburb = "Suburb"
                },
                DateOfBirth = BIRTHDAY,
                EmailAddress = "dimmy@dimmy.com",
                FirstName = "Dimmy",
                LastName = "Dimmington",
                PhoneNumber = "000"
            };
        }

        public static async Task<IList<CoverOptionDTO>> CreateCoverOptions(IContextFactory factory)
        {
            using (InsuranceDbContext ctx = factory.CreateContext())
            {
                ctx.CoverOptions.AddOrUpdate(
                    x => x.Id,

                    new CoverOption
                    {
                        Id = 1,
                        Code = "Bike-Basic",
                        AnnualPremium = (decimal)150.0,
                        Description = "Basic Bike Insurance",
                        CreatedAt = DateTime.UtcNow
                    }, new CoverOption
                    {
                        Id = 2,
                        Code = "Bike-Advanced",
                        AnnualPremium = (decimal)250.0,
                        Description = "Advanced Bike Insurance",
                        CreatedAt = DateTime.UtcNow
                    });

                await ctx.SaveChangesAsync();

                return ctx.CoverOptions.Select(x => new CoverOptionDTO()
                {
                    Code = x.Code,
                    Description = x.Description
                }).ToList();
            }


        }
    }
}
