using MediatR;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Domain.Interfaces;

namespace MyProfileAPI.Application.GoalsWidget.Commands;

public class AddGoalWidgetCommandHandler(IProfileRepository repository) : IRequestHandler<AddGoalWidgetCommand, Guid>
{
    private readonly IProfileRepository _repository = repository;

    public async Task<Guid> Handle(AddGoalWidgetCommand request, CancellationToken cancellationToken)
    {
        var profile = await _repository.GetByOngIdAsync(request.OngId, cancellationToken);
        if (profile is null)
            throw new NotFoundException("Perfil não encontrado.");

        profile.AddGoal(request.Title, request.Description, (int)request.TargetValue);
        await _repository.SaveAsync(profile, cancellationToken);

        return profile.Id;
    }
}

