using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Raci.B2C.Bicycle.Service.Util
{
    public static class IdentityExtensions
    {
        public static long? GetPolicyIdFromToken(this IIdentity identity)
        {
            long? result = null;
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.Claims.FirstOrDefault(x => x.Type.Equals("PolicyId"));

            if (claim != null)
            {
                result = long.Parse(claim.Value);
            }

            return result;
        }
    }
}