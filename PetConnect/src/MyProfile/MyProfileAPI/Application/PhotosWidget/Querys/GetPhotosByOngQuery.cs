using MediatR;
using MyProfileAPI.Application.PhotosWidget.DTOs;

namespace MyProfileAPI.Application.PhotosWidget.Querys;

public record GetPhotosByOngQuery(Guid OngId) : IRequest<IEnumerable<PhotoWidgetDto>>;
