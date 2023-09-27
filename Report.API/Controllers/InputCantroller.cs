using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Application.DTO.Input;
using Report.Application.DTO.Users;
using Report.Application.Service.Inputs;

namespace Report.API.Controllers;


[Route("api/inputs")]
[ApiController]
public class InputCantroller : ControllerBase
{
    private readonly IInputService inputService;

    public InputCantroller(IInputService inputService)
    {
        this.inputService = inputService;        
    }


    [Authorize(Roles = "HeadFamily")]
    [HttpPost]
    public async ValueTask<ActionResult<InputDto>> PostInputAsync(
       InputForCreationDto inputForCreationDto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;


        var createdInput = await this.inputService
            .CreateInputAsync(inputForCreationDto,Guid.Parse(userId));

        return Created("", createdInput);
    }


    [Authorize(Roles = "HeadFamily")]
    [HttpGet]
    public IActionResult GetAlInputAsnc(int year,int month)
    {
        DateTime date = DateTime.Parse($"01.{month}.{year}");
       
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        
        var user = this.inputService.RetrieveInputByDate(Guid.Parse(userId),date);
        return Ok(user);
    }


    [Authorize(Roles = "HeadFamily")]
    [HttpGet("Summa")]
    public double get(int year, int month)
    {
        DateTime date = DateTime.Parse($"01.{month}.{year}");
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        var summa = this.inputService.MonthlySumAsync(Guid.Parse(userId), date);

        return summa;

    }

    [Authorize(Roles = "HeadFamily")]
    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutInputAsync(
        InputForModificationDto inputForModificationDto)
    {
        var modifiedUser = await this.inputService
            .ModifyInputAsync(inputForModificationDto);

        return Ok(modifiedUser);
    }

    [Authorize(Roles = "HeadFamily")]
    [HttpDelete]
    public async ValueTask<ActionResult<UserDto>> DeleteInputAsync(
       Guid inputId)
    {
        var removed = await this.inputService
            .RemoveInputAsync(inputId);

        return Ok(removed);
    }
}
