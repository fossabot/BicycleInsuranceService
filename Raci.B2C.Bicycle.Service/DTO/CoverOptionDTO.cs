using System.ComponentModel.DataAnnotations;

namespace Raci.B2C.Bicycle.Service.DTO
{
    public class CoverOptionDTO
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal AnnualPremium { get; set; }

        [Required]

        public decimal MaximumAgreedValue { get; set; }

        [Required]

        public decimal MinimumAgreedValue { get; set; }

        [Required]
        public decimal Excess { get; set; }
    }
}