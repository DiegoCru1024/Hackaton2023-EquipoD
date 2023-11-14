namespace Application.Contracts.User.DTOs;

public class UserToken
{
    public string Token { get; set; }

    public UserToken(string token)
    {
        Token = token;
    }
}