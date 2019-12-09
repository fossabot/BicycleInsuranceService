using System;
using System.ComponentModel.DataAnnotations;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class Address
    {
        public long Id { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string PostCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}