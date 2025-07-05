using MediatR;

namespace MyProfileAPI.Application.PhotoWidget.Commands;

public record CreatePhotoWidgetCommand(Guid OngId, string Url, string Description) : IRequest<Guid>;

