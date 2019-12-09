using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.Models;
using CoverOptionDTO = Raci.B2C.Bicycle.Service.DTO.CoverOptionDTO;

namespace Raci.B2C.Bicycle.Service.Controllers
{
    public class CoverOptionsController : ApiController
    {
        private readonly IContextFactory _contextFactory;

        public CoverOptionsController(IContextFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentException("Cannot create controller with a null IInsuranceContextFactory.", nameof(factory));
            }

            _contextFactory = factory;
        }

        [HttpGet]
        [ResponseType(typeof(List<CoverOptionDTO>))]
        public async Task<IHttpActionResult> GetCoverOptions()
        {
            using (InsuranceDbContext ctx = _contextFactory.CreateContext())
            {
                IList<CoverOptionDTO> options = await ctx.CoverOptions.Select(co => new CoverOptionDTO()
                {
                    Code = co.Code,
                    Description = co.Description,
                    AnnualPremium = co.AnnualPremium,
                    Excess = co.Excess,
                    MaximumAgreedValue = co.MaximumAgreedValue,
                    MinimumAgreedValue = co.MinimumAgreedValue
                }).ToListAsync();

                return Ok(options);
            }
        }
    }
}
