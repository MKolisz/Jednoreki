using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
