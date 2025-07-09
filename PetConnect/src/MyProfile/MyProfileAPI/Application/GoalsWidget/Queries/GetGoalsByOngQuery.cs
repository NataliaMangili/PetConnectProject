using MediatR;
using MyProfileAPI.Application.GoalsWidget.Dto;

namespace MyProfileAPI.Application.GoalsWidget.Queries;

public record GetGoalsByOngQuery(Guid OngId) : IRequest<IEnumerable<GoalWidgetDto>>;

