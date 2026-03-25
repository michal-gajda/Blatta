namespace Blatta.WebApi.Controllers;

using Blatta.Application.Commands;
using Blatta.Application.Common;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public sealed class NameController(IBus bus) : ControllerBase
{
    [HttpPost(Name = "SetName")]
    public async Task<IActionResult> SetNameAsync(SetName command, CancellationToken cancellationToken)
    {
        await bus.Send(command, cancellationToken);

        return NoContent();
    }
}
