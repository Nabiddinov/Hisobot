using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Application.DTO.Users;
using Report.Application.Service.Users;

namespace Report.API.Controllers;


[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(
        IUserService userService)
    {
        this.userService = userService;
    }


    [HttpPost]
    public async ValueTask<ActionResult<UserDto>> PostUserAsync(
        UserForCreationDto userForCreationDto)
    {
        var createdUser = await this.userService
            .CreateUserAsync(userForCreationDto);

        return Created("", createdUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult GetAlUserAsnc()
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
        Console.WriteLine(userId);
        var user = this.userService.RetrieveUsers();
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
        Guid userId)
    {

        var user = await this.userService
            .RetrieveUserByIdAsync(userId);

        return Ok(user);
    }


    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutUserAsync(
        UserForModificationDto userForModificationDto)
    {
        var modifiedUser = await this.userService
            .ModifyUserAsync(userForModificationDto);

        return Ok(modifiedUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
        Guid userId)
    {
        var removed = await this.userService
            .RemoveUserAsync(userId);

        return Ok(removed);
    }
}


