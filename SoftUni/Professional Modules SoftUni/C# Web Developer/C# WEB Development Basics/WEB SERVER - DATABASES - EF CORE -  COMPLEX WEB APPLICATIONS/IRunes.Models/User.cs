namespace IRunes.Models
{
    public class User : BaseModel<int>
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}