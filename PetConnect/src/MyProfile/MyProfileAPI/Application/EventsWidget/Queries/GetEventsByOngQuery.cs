using MediatR;
using MyProfileAPI.Application.EventsWidget.Dtos;

namespace MyProfileAPI.Application.EventsWidget.Queries;

public record GetEventsByOngQuery(Guid OngId) : IRequest<IEnumerable<EventWidgetDto>>;
