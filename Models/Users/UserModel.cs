using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jednoreki.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public int TimePlayed { get; set; }
    }
}
