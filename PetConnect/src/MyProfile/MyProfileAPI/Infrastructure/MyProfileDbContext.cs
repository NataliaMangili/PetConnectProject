using global::MyProfileAPI.Models.Widgets;
using Microsoft.EntityFrameworkCore;
using MyProfileAPI.Domain.Models;
using MyProfileAPI.Domain.Models.Widgets;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyProfileAPI.Infra.Persistence;

public class MyProfileDbContext : DbContext
{
    public MyProfileDbContext(DbContextOptions<MyProfileDbContext> options) : base(options) { }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<PhotoWidget> PhotoWidgets { get; set; }
    public DbSet<GoalWidget> GoalWidgets { get; set; }
    public DbSet<EventWidget> EventWidgets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>().HasKey(x => x.Id);

        modelBuilder.Entity<Profile>()
            .OwnsMany(p => p.Gallery, b =>
            {
                b.WithOwner().HasForeignKey("ProfileId");
                b.Property<Guid>("Id");
                b.HasKey("Id");
            });

        modelBuilder.Entity<Profile>()
            .OwnsMany(p => p.Goals, b =>
            {
                b.WithOwner().HasForeignKey("ProfileId");
                b.Property<Guid>("Id");
                b.HasKey("Id");
            });

        modelBuilder.Entity<Profile>()
            .OwnsMany(p => p.Events, b =>
            {
                b.WithOwner().HasForeignKey("ProfileId");
                b.Property<Guid>("Id");
                b.HasKey("Id");
            });
    }
}
