using MediatR;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Application.GoalsWidget.Dto;
using MyProfileAPI.Domain.Interfaces;

namespace MyProfileAPI.Application.GoalsWidget.Queries;

public class GetGoalsByOngQueryHandler : IRequestHandler<GetGoalsByOngQuery, IEnumerable<GoalWidgetDto>>
{
    private readonly IGoalWidgetRepository _repository;

    public GetGoalsByOngQueryHandler(IGoalWidgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GoalWidgetDto>> Handle(GetGoalsByOngQuery request, CancellationToken cancellationToken)
    {
        var profile = await _repository.GetByOngIdAsync(request.OngId, cancellationToken)
            ?? throw new NotFoundException("Perfil não encontrado.");

        return profile.Goals
            .Select(goal => new GoalWidgetDto(goal.Id, goal.Title, goal.Description, goal.Target, goal.CreatedAt));
    }
}

