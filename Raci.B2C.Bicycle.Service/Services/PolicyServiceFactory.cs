using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Services
{
    public class PolicyServiceFactory
    {
        protected readonly IContextFactory ContextFactory;

        public PolicyServiceFactory(IContextFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public PolicyService GetPolicyService(Policy policy = null)
        {
            //
            // We only have bike at the moment so just return that one.
            //
            return new BicyclePolicyService(ContextFactory);
        }
    }
}