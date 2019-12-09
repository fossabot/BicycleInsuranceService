using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;
using Raci.B2C.Bicycle.Service.Services;
using Raci.B2C.Bicycle.Service.Util;

namespace Raci.B2C.Bicycle.Service.Controllers
{
    [RoutePrefix("api/bicyclepolicies")]
    public class BicyclePoliciesController : ApiController
    {
        private readonly BicyclePolicyService _service;

        public BicyclePoliciesController(IContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentException("Cannot create controller with a null IInsuranceContextFactory.", nameof(factory));
            }

            _service = new BicyclePolicyService(factory);
        }

        [HttpPost]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> Create([FromBody] BicyclePolicyDetailDTO details)
        {
            Policy policy = await _service.Create(details);
            return Ok(_service.ConvertToDto(policy));
        }

        [HttpPatch]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> SetDetails(long id, [FromBody] BicyclePolicyDetailDTO details)
        {
            long? tokenId = User.Identity.GetPolicyIdFromToken();

            if ( tokenId != id )
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Policy policy = await _service.SetDetails(id, details);
                return Ok(_service.ConvertToDto(policy));
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}