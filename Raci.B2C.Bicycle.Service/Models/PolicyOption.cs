using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class PolicyOption
    {
        public long Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal AnnualPremium { get; set; }

        [Required]
        public decimal Excess { get; set; }

        [Required]
        public string AgreedValue { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}