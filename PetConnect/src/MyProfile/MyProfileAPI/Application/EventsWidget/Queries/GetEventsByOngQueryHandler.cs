using MediatR;
using MyProfileAPI.Application.EventsWidget.Dtos;
using MyProfileAPI.Domain.Interfaces;

namespace MyProfileAPI.Application.EventsWidget.Queries;

public class GetEventsByOngQueryHandler(IEventWidgetRepository repository) : IRequestHandler<GetEventsByOngQuery, IEnumerable<EventWidgetDto>>
{
    private readonly IEventWidgetRepository _repository = repository;

    public async Task<IEnumerable<EventWidgetDto>> Handle(GetEventsByOngQuery request, CancellationToken cancellationToken)
    {
        var events = await _repository.GetByOngIdAsync(request.OngId, cancellationToken);

        return events.Select(e => new EventWidgetDto(e.Id, e.Title, e.Description, e.Date));
    }
}