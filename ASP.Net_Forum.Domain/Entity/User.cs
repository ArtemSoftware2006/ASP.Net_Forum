using ASP.Net_Forum.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ASP.Net_Forum.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public Role Role{ get; set; }
        public string Email { get; set; }
        public bool ConfirmEmail { get; set; }
        public List<Note> Notes { get; set; }
    }


}
