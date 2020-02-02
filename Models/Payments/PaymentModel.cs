using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jednoreki.Models.Payments
{
    public class PaymentModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
