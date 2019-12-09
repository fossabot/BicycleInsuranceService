using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class BicyclePolicyDetail
    {
        public long Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public string Type { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}