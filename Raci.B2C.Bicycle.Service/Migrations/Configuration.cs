using System;
using System.Data.Entity.Migrations;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<InsuranceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InsuranceDbContext context)
        {
            context.CoverOptions.AddOrUpdate (
                x => x.Id, 
                
                new CoverOption
                {
                    Id = 1,
                    Code = "2500",
                    AnnualPremium = (decimal) 150.0,
                    Description = "Basic Cover",
                    MinimumAgreedValue = (decimal)1000.0,
                    MaximumAgreedValue= (decimal)2500.0,
                    Excess = 200,
                    CreatedAt = DateTime.UtcNow
                }, new CoverOption
                {
                    Id = 2,
                    Code = "5000",
                    AnnualPremium = (decimal) 250.0,
                    Description = "Advanced Cover",
                    MinimumAgreedValue = (decimal)2501.0,
                    MaximumAgreedValue = (decimal)5000,
                    Excess = 200,
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}
