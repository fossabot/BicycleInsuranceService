using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class PolicyContact
    {
        public long Id { get; set; }

        public bool? IsPrimary { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public long? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}