using MyProfileAPI.Domain.Models.Widgets;

namespace MyProfileAPI.Domain.Interfaces;

public interface IEventWidgetRepository
{
    Task<IEnumerable<EventWidget>> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken);
    Task AddAsync(Guid ongId, EventWidget widget, CancellationToken cancellationToken);
}
