using MarketplaceAPI.Domain.Entities;

namespace MarketplaceAPI.Infra.Repositories.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(Guid id);
    Task<IEnumerable<Item>> GetByUserIdAsync(Guid userId);
    Task AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(Guid id);
}
