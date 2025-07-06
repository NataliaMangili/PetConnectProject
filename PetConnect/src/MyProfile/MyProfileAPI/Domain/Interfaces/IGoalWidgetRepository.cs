using MyProfileAPI.Domain.Models;
using MyProfileAPI.Domain.Models.Widgets;
using System.Threading.Tasks;

namespace MyProfileAPI.Domain.Interfaces;

public interface IGoalWidgetRepository
{
    Task<Profile?> GetByOngIdAsync(Guid ongId, CancellationToken cancellationToken);
    Task AddAsync(Guid ongId, GoalWidget widget, CancellationToken cancellationToken);
}
