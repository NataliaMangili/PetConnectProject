namespace MarketplaceAPI.Dtos.Item;

public class CreateMarketplaceItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuantityNeeded { get; set; }
    public Guid OngId { get; set; }
}
