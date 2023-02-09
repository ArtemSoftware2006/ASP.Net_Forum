using ASP.Net_Forum.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Login{ get; set; }
        public string Password { get; set; }
        public Role Role{ get; set; }
        public string Email { get; set; }
        [Column("Phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("Card_number")]
        public string? CardNumber { get; set; }
    }
}
