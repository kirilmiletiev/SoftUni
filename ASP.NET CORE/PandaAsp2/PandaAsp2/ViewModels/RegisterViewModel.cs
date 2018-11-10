using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaAsp2.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
