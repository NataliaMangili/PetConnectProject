using MarketplaceAPI.Domain.Entities;
using MarketplaceAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;

namespace MarketplaceAPI.Infra.Repositories;

public class ItemRepository(MarketplaceDbContext context) : Repository<Item>(context)
{
}