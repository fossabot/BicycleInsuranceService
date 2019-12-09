using System;

namespace Raci.B2C.Bicycle.Service.DTO
{
    public class PolicyContactDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public AddressDTO Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public bool ValidForPolicy()
        {
            return !string.IsNullOrEmpty(EmailAddress) && 
                   !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   DateOfBirth.HasValue &&
                   Address != null && 
                   Address.ValidForPolicy() &&
                   !string.IsNullOrEmpty(PhoneNumber);
        }
    }
}