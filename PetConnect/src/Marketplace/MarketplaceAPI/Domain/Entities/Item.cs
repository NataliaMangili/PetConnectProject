using System;

namespace MarketplaceAPI.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public Guid OngId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
}
