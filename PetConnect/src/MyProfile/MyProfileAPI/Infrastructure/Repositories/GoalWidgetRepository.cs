using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Domain.Interfaces;
using MyProfileAPI.Domain.Models.Widgets;
using MyProfileAPI.Infra.Persistence;
using System;

namespace MyProfileAPI.Infrastructure.Repositories;

public class GoalWidgetRepository(MyProfileDbContext context) : IGoalWidgetRepository
{
    private readonly MyProfileDbContext _context = context;

    public async Task<IEnumerable<GoalWidget>> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.OngId == ongId, cancellationToken);

        return profile?.Goals ?? Enumerable.Empty<GoalWidget>();
    }

    public async Task AddAsync(Guid ongId, GoalWidget widget, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.OngId == ongId, cancellationToken);

        if (profile is null)
            throw new NotFoundException("Perfil da ONG não encontrado.");

        profile.AddGoal(widget.Title, widget.Description, widget.Target);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
