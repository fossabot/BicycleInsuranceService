using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Controllers
{
    [RoutePrefix("api")]
    public class ReferenceDatasController : ApiController
    {
        private readonly IContextFactory _contextFactory;

        public ReferenceDatasController(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpGet]
        [Route("bicycletypes")]
        public ReferenceData[] GetBicycleTypes()
        {
            return ReadJson("BicycleTypes.json");
        }

        [HttpGet]
        [Route("suminsuredrange")]
        public async Task<MinMaxDTO> GetSumInuredRange()
        {
            using (InsuranceDbContext context = _contextFactory.CreateContext())
            {
                List<CoverOption> options = await context.CoverOptions.ToListAsync();

                MinMaxDTO result = new MinMaxDTO
                {
                    MinValue = options.Min(x => x.MinimumAgreedValue),
                    MaxValue = options.Max(x => x.MaximumAgreedValue)
                };

                return result;
            }
        }

        private ReferenceData[] ReadJson(string fileName)
        {
            string filePath = $"~/App_Data/{fileName}";
            string mappedPath = System.Web.Hosting.HostingEnvironment.MapPath(filePath);

            if (mappedPath == null)
            {
                throw new FileNotFoundException($"Unable to locate file {filePath}");
            }

            string json = File.ReadAllText(mappedPath);

            ReferenceData[] result = JsonConvert.DeserializeObject<ReferenceData[]>(json);

            foreach (ReferenceData currentItem in result)
            {
                if (string.IsNullOrWhiteSpace(currentItem.Id))
                {
                    currentItem.Id = currentItem.Description;
                }
            }

            return result;
        }
    }
}
