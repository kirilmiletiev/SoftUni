using PandaAsp2.Data.Models.Enums;

namespace PandaAsp2.Data.Models
{
    public interface IUser
    {
        string Email { get; set; }
        string Password { get; set; }
        Role Role { get; set; }
        string UserName { get; set; }
    }
}