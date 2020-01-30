using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Jednoreki.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public int TimePlayed { get; set; }
    }
}
