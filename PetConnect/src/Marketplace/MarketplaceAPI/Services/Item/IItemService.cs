using MarketplaceAPI.Domain.Entities;
using MarketplaceAPI.Dtos.Item;

namespace MarketplaceAPI.Services.Item;

public interface IItemService
{
    Task<IEnumerable<Domain.Entities.Item>> GetAllItemsAsync();
    Task<Domain.Entities.Item> GetItemByIdAsync(Guid id);
    Task CreateItemAsync(CreateMarketplaceItemDto dto);
    Task UpdateItemAsync(Guid id, UpdateMarketplaceItemDto dto);
    Task DeleteItemAsync(Guid id);
    Task<IEnumerable<Domain.Entities.Item>> GetItemsByUserAsync(Guid userId);
}
