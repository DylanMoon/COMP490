using GitMunnyApi.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace GitMunnyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    
    // [HttpGet("{id}")]
    // public asnyc 
    
}