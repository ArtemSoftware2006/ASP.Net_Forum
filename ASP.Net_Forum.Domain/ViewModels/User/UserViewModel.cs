﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Column("Phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("Card_number")]
        public string? CardNumber { get; set; }
    }
}
