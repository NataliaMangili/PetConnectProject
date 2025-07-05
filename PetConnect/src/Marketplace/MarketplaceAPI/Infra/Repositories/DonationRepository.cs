using MarketplaceAPI.Domain.Entities;
using MarketplaceAPI.Infra.Repositories.Interfaces;

namespace MarketplaceAPI.Infra.Repositories;

public class DonationRepository : Repository<Donation>, IDonationRepository
{
    public DonationRepository(MarketplaceDbContext context) : base(context) { }

    // Métodos específicos para doações, ex: Buscar por item ou doador
}
