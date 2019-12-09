using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class CoverOption
    {
        public long Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal AnnualPremium { get; set; }

        [Required]
        public decimal MinimumAgreedValue { get; set; }

        [Required]
        public decimal MaximumAgreedValue { get; set; }

        [Required]
        public decimal Excess { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}