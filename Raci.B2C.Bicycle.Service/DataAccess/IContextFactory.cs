using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.DataAccess
{
    public interface IContextFactory
    {
        InsuranceDbContext CreateContext();
    }
}