using System.ComponentModel.DataAnnotations;

namespace Raci.B2C.Bicycle.Service.DTO
{
    public class BicyclePolicyDetailDTO
    {
        [Required]
        public string Make;
        [Required]
        public string Model;
        [Required]
        public string Year;
        [Required]
        public string Type;
    }
}