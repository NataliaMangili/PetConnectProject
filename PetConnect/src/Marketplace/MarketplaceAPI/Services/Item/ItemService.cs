using MarketplaceAPI.Domain.Entities;
using MarketplaceAPI.Dtos.Item;
using MarketplaceAPI.Infra.Repositories.Interfaces;

namespace MarketplaceAPI.Services.Item;

public class ItemService : IItemService
{
    private readonly IItemRepository _repo;

    public ItemService(IItemRepository repo) => _repo = repo;

    public async Task<IEnumerable<Domain.Entities.Item>> GetAllItemsAsync() =>
        await _repo.GetAllAsync();

    public async Task<Domain.Entities.Item> GetItemByIdAsync(Guid id) =>
        await _repo.GetByIdAsync(id);

    public async Task CreateItemAsync(CreateMarketplaceItemDto dto)
    {
        var item = new Domain.Entities.Item
        {
            Id = Guid.NewGuid(),
            OngId = dto.OngId,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };
        await _repo.AddAsync(item);
    }

    public async Task UpdateItemAsync(Guid id, UpdateMarketplaceItemDto dto)
    {
        var item = await _repo.GetByIdAsync(id);
        item.Name = dto.Name;
        item.Description = dto.Description;
        await _repo.UpdateAsync(item);
    }

    public async Task DeleteItemAsync(Guid id) => await _repo.DeleteAsync(id);

    public async Task<IEnumerable<Domain.Entities.Item>> GetItemsByUserAsync(Guid userId) =>
        await _repo.GetByUserIdAsync(userId);
}

