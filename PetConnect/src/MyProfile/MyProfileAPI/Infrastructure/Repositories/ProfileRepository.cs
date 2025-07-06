using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Domain.Interfaces;
using MyProfileAPI.Domain.Models;
using MyProfileAPI.Infra.Persistence;

namespace MyProfileAPI.Infrastructure.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly MyProfileDbContext _context;

    public ProfileRepository(MyProfileDbContext context)
    {
        _context = context;
    }

    public async Task<Profile?> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken)
    {
        return await _context.Profiles.FirstOrDefaultAsync(p => p.OngId == ongId, cancellationToken);
    }

    public async Task SaveAsync(Profile profile, CancellationToken cancellationToken)
    {
        _context.Update(profile);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
