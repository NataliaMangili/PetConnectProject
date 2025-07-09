using MediatR;

namespace MyProfileAPI.Application.EventsWidget.Commands;

public record AddEventWidgetCommand(Guid OngId, string Title, string Description, DateTime Date)
    : IRequest<Guid>;