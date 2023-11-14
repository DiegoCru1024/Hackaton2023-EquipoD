namespace Application.Contracts.User.DTOs;

public class RegisterUser
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}