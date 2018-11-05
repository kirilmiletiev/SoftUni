using PANDA.App.Models.Enums;

namespace PANDA.App.ViewModel
{
    public class LoginViewModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
