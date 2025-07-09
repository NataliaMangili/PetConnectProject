using MediatR;

namespace MyProfileAPI.Application.PhotosWidget.Commands;

public record CreatePhotoWidgetCommand(Guid OngId, string Url, string Description) : IRequest<Guid>;

