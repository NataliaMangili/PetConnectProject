using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Application.ExcpetionsCommon;
using MyProfileAPI.Domain.Interfaces;
using MyProfileAPI.Domain.Models.Widgets;
using MyProfileAPI.Infra.Persistence;
using System;

namespace MyProfileAPI.Infrastructure.Repositories;

public class EventWidgetRepository(MyProfileDbContext context) : IEventWidgetRepository
{
    private readonly MyProfileDbContext _context = context;

    public async Task<IEnumerable<EventWidget>> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles.AsNoTracking()
            .FirstOrDefaultAsync(p => p.OngId == ongId, cancellationToken);

        return profile?.Events ?? Enumerable.Empty<EventWidget>();
    }

    public async Task AddAsync(Guid ongId, EventWidget widget, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles
            .FirstOrDefaultAsync(p => p.OngId == ongId, cancellationToken);

        if (profile is null)
            throw new NotFoundException("Perfil da ONG não encontrado.");

        profile.AddEvent(widget.Title, widget.Date, widget.Description);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
