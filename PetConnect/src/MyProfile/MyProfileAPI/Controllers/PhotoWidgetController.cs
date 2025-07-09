using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProfileAPI.Application.PhotosWidget.Commands;
using MyProfileAPI.Application.PhotosWidget.Querys;

namespace MyProfileAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotoWidgetController : ControllerBase
{
    //private readonly IMediator _mediator;

    //public PhotoWidgetController(IMediator mediator)
    //{
    //    _mediator = mediator;
    //}

    //[HttpPost]
    //public async Task<IActionResult> AddPhoto([FromBody] CreatePhotoWidgetCommand command)
    //{
    //    var id = await _mediator.Send(command);
    //    return CreatedAtAction(nameof(GetPhotos), new { ongId = command.OngId }, new { id });
    //}

    //[HttpGet("{ongId:guid}")]
    //public async Task<IActionResult> GetPhotos(Guid ongId)
    //{
    //    var result = await _mediator.Send(new GetPhotosByOngQuery(ongId));
    //    return Ok(result);
    //}
}

