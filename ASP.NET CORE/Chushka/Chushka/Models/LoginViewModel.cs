﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }    

        public bool IsLoggedIn { get; set; }    
    }
}
