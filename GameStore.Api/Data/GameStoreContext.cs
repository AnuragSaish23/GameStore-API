using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Name = "Street Fighter II", Genre = "Fighting", Price = 19.99M, ReleaseDate = new DateOnly(1992, 7, 15) },
            new Game { Id = 2, Name = "Final Fantasy XIV", Genre = "RPG", Price = 59.99M, ReleaseDate = new DateOnly(2024, 2, 29) },
            new Game { Id = 3, Name = "Astro Bot", Genre = "Platformer", Price = 59.99M, ReleaseDate = new DateOnly(2024, 9, 6) }
        );
    }
}
