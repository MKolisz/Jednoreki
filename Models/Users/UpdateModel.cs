using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Models.Users
{
    public class UpdateModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public int TimePlayed { get; set; }
    }
}
