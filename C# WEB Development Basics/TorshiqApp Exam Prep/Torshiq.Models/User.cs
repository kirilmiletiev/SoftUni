namespace Torshiq.Models
{
    public class User: BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
