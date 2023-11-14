using Application.Contracts.User.DTOs;

namespace Application.Services;

public interface IUserService
{
    Task<UserToken> CreateUser(RegisterUser model);
    Task<UserToken> LoginUser(LoginUser model);
}