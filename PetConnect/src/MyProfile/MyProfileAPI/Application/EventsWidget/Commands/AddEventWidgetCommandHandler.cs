using MediatR;
using MyProfileAPI.Domain.Interfaces;
using MyProfileAPI.Domain.Models.Widgets;

namespace MyProfileAPI.Application.EventsWidget.Commands;

public class AddEventWidgetCommandHandler(IEventWidgetRepository repository) : IRequestHandler<AddEventWidgetCommand, Guid>
{
    private readonly IEventWidgetRepository _repository = repository;

    public async Task<Guid> Handle(AddEventWidgetCommand request, CancellationToken cancellationToken)
    {
        var widget = EventWidget.Create(request.Title, request.Date, request.Description);

        await _repository.AddAsync(request.OngId, widget, cancellationToken);

        return widget.Id;
    }
}
