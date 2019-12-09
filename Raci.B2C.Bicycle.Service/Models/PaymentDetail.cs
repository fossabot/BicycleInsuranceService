using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raci.B2C.Bicycle.Service.Models
{
    public class PaymentDetail
    {
        public long Id { get; set; }

        [Required]
        public string TransactionId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}