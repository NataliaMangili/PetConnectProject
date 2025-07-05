namespace MarketplaceAPI.Domain.Entities;

public class Donation
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public Guid DonorId { get; set; }

    public int Quantity { get; set; }

    //TODO: Transformar em ENUM Status: Pending, Confirmed, Canceled
    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }
}