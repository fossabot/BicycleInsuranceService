using System.Data.Entity;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.DataAccess
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext()
        {
        }

        public InsuranceDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Policy>  Policies { get; set; }
        public DbSet<CoverOption> CoverOptions { get; set; }
    }
}