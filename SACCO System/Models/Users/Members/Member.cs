namespace SACCO_MANAGEMENT.Models.Users.Members
{
    public class Member
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Email { get; set; }
        int PhoneNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        //bool DeleteRequest { get; set; }

    }
}
