using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Jednoreki.Models.Games
{
    public class GameModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Balance { get; set; }
    }
}
