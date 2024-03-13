using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers.User.Requests;
using ProfileApi.Controllers.User.Responses;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileApi.Controllers;

[Route("public/user")]
public class UserController: ControllerBase
{
    private readonly IUserLogicManager _userLogicManager;
    
    public UserController(IUserLogicManager userLogicManager)
    {
        _userLogicManager = userLogicManager;
    }
    
    [ProducesResponseType<UserInfoResponse>(200)]
    [HttpGet("info")]
    public async Task<IActionResult> GetInfoAsync([FromQuery] Guid userId)
    {
        var userName = await _userLogicManager.GetUserNameAsync(userId);
        return Ok(new UserInfoResponse
        {
            Id = default,
            Name = null,
            Login = null,
            BirthDate = null,
            Information = null
        });
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), 200)]
    public async Task<ActionResult> AddNewUserAsync([FromBody] CreateUserRequest dto)
    {
        var res = await _userLogicManager.AddNewUserAsync(new UserLogic
        {
            Name = dto.Name,
            Login = dto.Login,
            BirthDate = dto.BirthDate,
            Information = dto.Information
        });
        
        return Ok(new CreateUserResponse
        {
            Id = res
        });
    }
    
    [HttpPost("exist")]
    [ProducesResponseType(typeof(CreateUserResponse),200)]
    public async Task<IActionResult> CheckUserExistProfile([FromQuery] Guid userId)
    {
        var res = await _userLogicManager.CheckUserExist(userId);
        return Ok(new CreateUserResponse()
        {
            Id = res
        });
    }
}