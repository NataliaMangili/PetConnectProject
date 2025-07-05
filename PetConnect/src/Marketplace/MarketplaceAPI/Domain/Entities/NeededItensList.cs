using System;

namespace MarketplaceAPI.Domain.Entities;

public class ItemNeedList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OngId { get; set; }
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public string Category { get; set; }
    public int QuantityNeeded { get; set; }
    public int QuantityFulfilled { get; set; }

    // TODO: Transformar em ENUM Status: Pending, Fulfilled, Expired, Removed
    public string Status { get; set; }
    public string Notes { get; set; } // Detalhes adicionais (opcional)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}