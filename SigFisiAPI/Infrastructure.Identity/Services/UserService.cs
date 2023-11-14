using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.User.DTOs;
using Application.Exceptions;
using Application.Services;
using AutoMapper;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IValidationService _validationService;
    private readonly IConfiguration _configuration;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,
        IConfiguration configuration, IValidationService validationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _configuration = configuration;
        _validationService = validationService;
    }

    public async Task<UserToken> CreateUser(RegisterUser model)
    {
        _validationService.EnsureValid(model);

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            throw new AppException("El usuario ya existe");
        }

        var newUser = _mapper.Map<User>(model);

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.ToString());
        }

        await _userManager.AddToRoleAsync(newUser, model.Role);

        return GenerateJwtToken(newUser, model.Role);

    }

    public async Task<UserToken> LoginUser(LoginUser model)
    {
        _validationService.EnsureValid(model);

        var user = await _userManager.FindByEmailAsync(model.Email);

        var userRoles = await _userManager.GetRolesAsync(user);

        if(user == null)
            throw new AppException("Verifique sus credenciales");

        var loginResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

        if (!loginResult.Succeeded)
            throw new AppException("Verifique sus credenciales");

        return GenerateJwtToken(user, userRoles.FirstOrDefault());
    }
    private UserToken GenerateJwtToken(User user, string? role)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
        };

        if (role != null)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

        var token = new JwtSecurityToken(
            null,
            null,
            claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new UserToken(new JwtSecurityTokenHandler().WriteToken(token));
    }
}