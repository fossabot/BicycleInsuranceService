using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Raci.B2C.Bicycle.Service.DataAccess;
using Raci.B2C.Bicycle.Service.DTO;
using Raci.B2C.Bicycle.Service.Models;

namespace Raci.B2C.Bicycle.Service.Services
{
    public abstract class PolicyService
    {
        protected readonly IContextFactory ContextFactory;

        protected PolicyService(IContextFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public abstract Task<PolicyOption> CalculatePolicyOption(Policy policy);

        protected virtual IQueryable<Policy> GetPolicySet(InsuranceDbContext context)
        {
            return context.Policies
                .Include(x => x.Contact.Address)
                .Include(x => x.Option)
                .Include(x => x.Payment);
        }

        protected async Task<Policy> FetchPolicy(InsuranceDbContext context, long id, bool isForUpdate)
        {
            Policy policy = await GetPolicySet(context).SingleAsync(x => x.Id == id);
            //
            // If policy has been issued then we are not allowed to fetch it for updates.
            //
            if ((isForUpdate ) && (policy.IsIssued))
            {
                throw new BadRequestException("Cannot update an issued Policy.");
            }

            return policy;
        }

        public async Task<Policy> GetPolicy(long id)
        {
            Policy policy;

            using (InsuranceDbContext context = ContextFactory.CreateContext())
            {
                policy = await FetchPolicy(context, id, false);
            }

            return policy;
        }

        public async Task<Policy> SetContact(long id, PolicyContactDTO contact)
        {
            if (contact == null)
            {
                throw new BadRequestException();
            }

            using (InsuranceDbContext context = ContextFactory.CreateContext())
            {
                Policy policy = await FetchPolicy(context, id, true);

                policy.Contact = CreateContactFromDto(policy.Contact, contact);

                await context.SaveChangesAsync();

                return policy;
            }
        }

        public async Task<Policy> SetPolicyOption(long policyId, PolicyOptionDTO option)
        {
            if (option == null)
            {
                throw new BadRequestException();
            }

            using (InsuranceDbContext context = ContextFactory.CreateContext())
            {
                Policy policy = await FetchPolicy(context, policyId, true);

                if (policy.Option == null)
                {
                    await CalculatePolicyOption(policy);
                }

                policy.Option = CreatePolicyOptionFromCoverOption(policy.Option, option);
                policy.Option = await CalculatePolicyOption(policy);

                await context.SaveChangesAsync();

                return policy;
            }
        }

        public async Task MarkAsPaid(long quoteId, string transactionId)
        {
            if (String.IsNullOrEmpty(transactionId))
            {
                throw new BadRequestException();
            }

            using (InsuranceDbContext ctx = ContextFactory.CreateContext())
            {
                Policy policy = await ctx.Policies.SingleAsync(x => x.Id == quoteId);

                if (policy.IsIssued)
                {
                    throw new BadRequestException("Cannot update an issued Policy.");
                }

                // set the state of the policy to policy now we know it's been paid.
                policy.State = PolicyState.Policy;
                policy.Payment = new PaymentDetail()
                {
                    TransactionId = transactionId,
                    CreatedAt = DateTime.UtcNow
                };

                policy.PolicyNumber = "BKE" +  policy.Id.ToString("D9");

                await ctx.SaveChangesAsync();
            }
        }

        public virtual PolicyDTO ConvertToDto(Policy policy)
        {
            PolicyDTO dto = new PolicyDTO()
            {
                Id = policy.Id,
                PolicyNumber = policy.PolicyNumber,
                IsNew = policy.State == PolicyState.New,
                IsQuote = policy.State == PolicyState.Quote,
                IsPolicy = policy.State == PolicyState.Policy
            };

            if (policy.Contact != null)
            {
                CreateContactDto(policy, dto);
            }

            if (policy.Option != null)
            {
                CreatePolicyOptionDto(policy, dto);
            }

            if (policy.Payment != null)
            {
                CreatePaymentDetailDto(policy, dto);
            }

            return dto;
        }

        protected void CreatePaymentDetailDto(Policy pol, PolicyDTO dto)
        {
            PaymentDetail payment = pol.Payment;

            dto.Payment = new PaymentDetailDTO()
            {
                TransactionId = payment.TransactionId
            };
        }

        protected void CreatePolicyOptionDto(Policy pol, PolicyDTO dto)
        {
            PolicyOption option = pol.Option;

            dto.Option = new PolicyOptionDTO()
            {
                AnnualPremium = option.AnnualPremium,
                Code = option.Code,
                Description = option.Description,
                Excess = option.Excess,
                AgreedValue = option.AgreedValue
            };
        }

        protected static void CreateContactDto(Policy pol, PolicyDTO dto)
        {
            PolicyContact contact = pol.Contact;

            dto.Contact = new PolicyContactDTO()
            {
                DateOfBirth = contact.DateOfBirth,
                EmailAddress = contact.EmailAddress,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber
            };

            if (contact.Address != null)
            {
                dto.Contact.Address = new AddressDTO()
                {
                    AddressLine1 = contact.Address.AddressLine1,
                    PostCode = contact.Address.PostCode,
                    Suburb = contact.Address.Suburb
                };
            }
        }

        private PolicyOption CreatePolicyOptionFromCoverOption(PolicyOption option, PolicyOptionDTO optionDto)
        {
            option.AgreedValue = optionDto.AgreedValue;
            return option;
        }

        protected PolicyContact CreateContactFromDto(PolicyContact contact, PolicyContactDTO contactDto)
        {
            if (contact == null)
            {
                contact = new PolicyContact
                {
                    CreatedAt = DateTime.UtcNow
                };
            }

            contact.DateOfBirth = contactDto.DateOfBirth;
            contact.EmailAddress = contactDto.EmailAddress;
            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;
            contact.PhoneNumber = contactDto.PhoneNumber;

            if (contactDto.Address != null)
            {
                if (contact.Address == null)
                {
                    contact.Address = new Address
                    {
                        CreatedAt = DateTime.UtcNow
                    };
                }

                contact.Address.AddressLine1 = contactDto.Address.AddressLine1;
                contact.Address.PostCode = contactDto.Address.PostCode;
                contact.Address.Suburb = contactDto.Address.Suburb;
            }

            return contact;
        }
    }
}