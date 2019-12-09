using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;
using Raci.B2C.Bicycle.Service.Services;
using Raci.B2C.Bicycle.Service.Util;

namespace Raci.B2C.Bicycle.Service.Controllers
{
    [RoutePrefix("api/policies")]
    public class PoliciesController : ApiController
    {
        private readonly PolicyServiceFactory _serviceFactory;

        public PoliciesController(PolicyServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> GetPolicy(long id)
        {
            long? tokenId = User.Identity.GetPolicyIdFromToken();

            if (tokenId != id)
            {
                return Unauthorized();
            }

            try
            {
                PolicyService service = _serviceFactory.GetPolicyService();
                return Ok(service.ConvertToDto(await service.GetPolicy(id)));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("contact")]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> SetContact(long id, [FromBody] PolicyContactDTO contact)
        {
            long? tokenId = User.Identity.GetPolicyIdFromToken();

            if (tokenId != id)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Policy policy = await _serviceFactory.GetPolicyService().SetContact(id, contact);
                return Ok(_serviceFactory.GetPolicyService().ConvertToDto(policy));
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

        [HttpPatch]
        [ResponseType(typeof(PolicyDTO))]
        [Route("option")]
        public async Task<IHttpActionResult> SetPolicyOption(long id, [FromBody] PolicyOptionDTO options)
        {
            long? tokenId = User.Identity.GetPolicyIdFromToken();

            if (tokenId != id)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Policy policy = await _serviceFactory.GetPolicyService().SetPolicyOption(id, options);
                return Ok(_serviceFactory.GetPolicyService().ConvertToDto(policy));
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

        [HttpPut]
        [Route("payment")]
        public async Task<IHttpActionResult> MarkAsPaid([FromBody] string transactionId)
        {
            long? id = User.Identity.GetPolicyIdFromToken();

            if (!id.HasValue)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serviceFactory.GetPolicyService().MarkAsPaid(id.Value, transactionId);
                return Ok();
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