using Application.Contracts.User.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // POST: api/Users/Register
    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser(RegisterUser model)
    {
        return Ok(await _userService.CreateUser(model));
    }

    // POST: api/Users/Login
    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser(LoginUser model)
    {
        return Ok(await _userService.LoginUser(model));
    }
}