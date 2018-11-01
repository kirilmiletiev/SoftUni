using System.Collections.Generic;
using Torshiq.Models.Enums;

namespace Torshiq.App.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Roles = new List<string>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool  IsValid { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
