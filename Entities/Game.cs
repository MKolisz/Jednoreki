using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jednoreki.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Balance { get; set; }
    }
}
