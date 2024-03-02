using Logic.Users.Interfaces;
using Logic.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Ruztagram.Controllers.Users.Requests;
using Ruztagram.Controllers.Users.Responses;

namespace Ruztagram.Controllers;

[Route("public/user")]
public class UserController: ControllerBase
{
    private readonly IUserLogicManager _userLogicManager;
    
    public UserController(IUserLogicManager userLogicManager)
    {
        _userLogicManager = userLogicManager;
    }
    
    [ProducesResponseType<UserInfoResponse>(200)]
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
}