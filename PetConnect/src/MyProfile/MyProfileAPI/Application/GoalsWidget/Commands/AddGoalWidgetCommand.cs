using MediatR;

namespace MyProfileAPI.Application.GoalsWidget.Commands;

public record AddGoalWidgetCommand(Guid OngId, string Title, string Description, decimal TargetValue)
    : IRequest<Guid>;
