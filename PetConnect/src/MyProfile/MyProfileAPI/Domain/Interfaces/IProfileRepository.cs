using MyProfileAPI.Domain.Models;

namespace MyProfileAPI.Domain.Interfaces;

public interface IProfileRepository
{
    Task<Profile?> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken);
    Task SaveAsync(Profile profile, CancellationToken cancellationToken);
}
