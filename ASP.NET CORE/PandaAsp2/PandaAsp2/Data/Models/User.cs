using Microsoft.AspNetCore.Identity;
using PandaAsp2.Data.Models.Enums;

namespace PandaAsp2.Data.Models
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

    }
}
