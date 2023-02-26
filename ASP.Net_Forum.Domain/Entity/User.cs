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
    public class User : IdentityUser<int>
    {
        public int Age { get; set; }
        public Role Role{ get; set; }

        [Column("Card_number")]
        public string? CardNumber { get; set; }
    }


}
