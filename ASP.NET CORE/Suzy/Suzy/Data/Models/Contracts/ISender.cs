namespace Suzy.Data.Models.Contracts
{
    public interface ISender
    {
        string Address { get; set; }
        int Age { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string UserName { get; set; }
    }
}