using MediatR;
using MyProfileAPI.Application.PhotoWidget.DTOs;

namespace MyProfileAPI.Application.PhotoWidget.Querys;

public record GetPhotosByOngQuery(Guid OngId) : IRequest<IEnumerable<PhotoWidgetDto>>;
