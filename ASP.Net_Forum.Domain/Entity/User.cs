﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Login{ get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
    }
}
