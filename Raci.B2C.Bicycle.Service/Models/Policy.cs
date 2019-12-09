using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class Policy
    {
        public long Id { get; set; }

        public string PolicyNumber { get; set; }

        public string Description { get; set; }

        [Required]
        public PolicyState State { get; set; }

        public long? DetailId { get; set; }

        public long? ContactId { get; set; }

        public long? OptionId { get; set; }

        public long? PaymentId { get; set; }

        [ForeignKey("DetailId")]
        public virtual BicyclePolicyDetail Detail { get; set; }

        [ForeignKey("ContactId")]
        public virtual PolicyContact Contact { get; set; }

        [ForeignKey("OptionId")]
        public virtual PolicyOption Option { get; set; }

        [ForeignKey("PaymentId")]
        public virtual PaymentDetail Payment { get; set; }

        [Required]
        public virtual DateTime CreatedAt { get; set; }

        public bool IsIssued => State == PolicyState.Policy;
    }
}