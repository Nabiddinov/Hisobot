using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Application.DTO.Output;
using Report.Application.DTO.Users;
using Report.Application.Service.Outputs;

namespace Report.API.Controllers;

[Route("api/outputs")]
[ApiController]
public class OutputCantroller : ControllerBase
{
    private readonly IOutputService outputService;

    public OutputCantroller(IOutputService outputService)
    {
        this.outputService = outputService;
    }

    [Authorize(Roles = "HeadFamily")]
    [HttpPost]
    public async ValueTask<ActionResult<OutputDto>> PostOutputAsync(
      OutputForCreationDto outputForCreationDto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        var createdInput = await this.outputService
            .CreateOutputAsync(outputForCreationDto, Guid.Parse(userId));

        return Created("", createdInput);
    }


    [Authorize(Roles = "HeadFamily")]
    [HttpGet]
    public IActionResult GetAlOutputAsnc(int year, int month)
    {
        DateTime date = DateTime.Parse($"01.{month}.{year}");
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        var user = this.outputService.RetrieveOutputByDate(Guid.Parse(userId), date);
        return Ok(user);
    }

    [Authorize(Roles = "HeadFamily")]
    [HttpGet("Summa")]
    public double get(int year, int month)
    {
        DateTime date = DateTime.Parse($"01.{month}.{year}");
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

        var summa = this.outputService.MonthlySumAsync(Guid.Parse(userId), date);

        return summa;

    }


    [Authorize(Roles = "HeadFamily")]
    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutOutputAsync(
        OutputForModificationDto outputForModificationDto)
    {
        var modifiedUser = await this.outputService
            .ModifyOutputAsync(outputForModificationDto);

        return Ok(modifiedUser);
    }


    [Authorize(Roles = "HeadFamily")]
    [HttpDelete]
    public async ValueTask<ActionResult<UserDto>> DeleteInputAsync(
       Guid userId)
    {
        var removed = await this.outputService
            .RemoveOutputAsync(userId);

        return Ok(removed);
    }
}
