namespace Project.Models;

public class Client
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CNP { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
}