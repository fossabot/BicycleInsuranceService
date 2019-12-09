using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Services
{
    public class BicyclePolicyService : PolicyService
    {
        public BicyclePolicyService(IContextFactory contextFactory) : base(contextFactory)
        {
        }

        protected override IQueryable<Policy> GetPolicySet(InsuranceDbContext context)
        {
            IQueryable<Policy> result = base.GetPolicySet(context).Include(x => x.Detail);
            return result;
        }

        public async Task<Policy> Create(BicyclePolicyDetailDTO policyDto)
        {
            using (InsuranceDbContext ctx = ContextFactory.CreateContext())
            {
                Policy policy = new Policy()
                {
                    State = PolicyState.Quote,
                    Description = "Bicycle Insurance",
                    CreatedAt = DateTime.UtcNow,
                    Detail = CreateDetailModelFromDto(policyDto)
                };

                policy.Option = await CalculatePolicyOption(policy);

                ctx.Policies.Add(policy);
                await ctx.SaveChangesAsync();

                policy.PolicyNumber = $"QTE{policy.Id:D9}";
                await ctx.SaveChangesAsync();

                return policy;
            }
        }

        public override async Task<PolicyOption> CalculatePolicyOption(Policy policy)
        {
            PolicyOption result;
            List<CoverOption> coverOptions;

            using (InsuranceDbContext context = ContextFactory.CreateContext())
            {
                coverOptions = await context.CoverOptions.OrderBy(x => x.MinimumAgreedValue).ToListAsync();
            }

            if (policy.Option == null)
            {
                //
                // Create a new option
                //
                result = new PolicyOption();

                CoverOption firstOption = coverOptions.First();

                result.Code = firstOption.Code;
                result.Description = firstOption.Description;
                result.AgreedValue = firstOption.MinimumAgreedValue.ToString(CultureInfo.InvariantCulture);
                result.Excess = firstOption.Excess;
                result.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                //
                // Keep the object and just recaclulate the premium
                //
                result = policy.Option;
            }

            decimal agreedValue = Convert.ToDecimal(result.AgreedValue);

            CoverOption matchingCover = coverOptions.FirstOrDefault(x => x.MinimumAgreedValue <= agreedValue && x.MaximumAgreedValue >= agreedValue);

            if (matchingCover == null)
            {
                throw new BadRequestException("Unable to determine annual premium");
            }

            result.Code = matchingCover.Code;
            result.Description = matchingCover.Description;
            result.AnnualPremium = matchingCover.AnnualPremium;

            return result;
        }

        public async Task<Policy> SetDetails(long id, BicyclePolicyDetailDTO details)
        {
            if (details == null)
            {
                throw new BadRequestException();
            }

            using (InsuranceDbContext ctx = ContextFactory.CreateContext())
            {
                Policy policy = await ctx.Policies.SingleAsync(x => x.Id == id);

                if (policy.IsIssued)
                {
                    throw new BadRequestException("Cannot update an issued Policy.");
                }

                policy.Detail = CreateDetailModelFromDto(details);
                policy.Option = await CalculatePolicyOption(policy);

                await ctx.SaveChangesAsync();

                return policy;
            }
        }

        protected BicyclePolicyDetail CreateDetailModelFromDto(BicyclePolicyDetailDTO details)
        {
            BicyclePolicyDetail detail = new BicyclePolicyDetail()
            {
                Make = details.Make,
                Model = details.Model,
                Type = details.Type,
                Year = details.Year,
                CreatedAt = DateTime.UtcNow
            };

            return detail;
        }

        public override PolicyDTO ConvertToDto(Policy policy)
        {
            PolicyDTO dto = base.ConvertToDto(policy);

            if (policy.Detail != null)
            {
                CreatePolicyDetailDto(policy, dto);
            }

            return dto;
        }

        protected void CreatePolicyDetailDto(Policy pol, PolicyDTO dto)
        {
            BicyclePolicyDetail detail = pol.Detail;

            dto.Detail = new BicyclePolicyDetailDTO()
            {
                Make = detail.Make,
                Model = detail.Model,
                Type = detail.Type,
                Year = detail.Year
            };
        }
    }
}