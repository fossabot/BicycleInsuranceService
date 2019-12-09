using System.ComponentModel.DataAnnotations;

namespace Raci.B2C.Bicycle.Service.DTO
{
    public class AddressDTO
    {
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string PostCode { get; set; }

        public bool ValidForPolicy()
        {
            return !string.IsNullOrEmpty(AddressLine1) &&
                   !string.IsNullOrEmpty(Suburb) &&
                   !string.IsNullOrEmpty(PostCode);

        }
    }
}