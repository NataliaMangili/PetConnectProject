using Microsoft.EntityFrameworkCore;
using IdentityCore.Domain.Entities;

namespace IdentityInfra;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Ong> Ongs { get; set; }
    public DbSet<Protector> Protectors { get; set; }
}
