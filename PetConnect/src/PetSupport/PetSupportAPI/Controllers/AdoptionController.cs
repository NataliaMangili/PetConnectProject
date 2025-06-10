using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetSupportApplication.Adoption.Commands.CreateAdoption;

namespace PetSupportAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdoptionController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdoptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAdoptionCommand command)
    {
        var id = await _mediator.Send(command);
        return null;
    }
}
