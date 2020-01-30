using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Models.Payments
{
    public class PaymentModel
    {
        public int UserId { get; set; }
        public float Amount { get; set; }
    }
}
