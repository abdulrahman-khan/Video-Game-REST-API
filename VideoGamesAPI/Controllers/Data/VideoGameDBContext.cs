using Microsoft.EntityFrameworkCore;
using VideoGamesAPI.Entities;
using VideoGamesAPI.Models;


namespace VideoGamesAPI.Controllers.Data
{
    public class VideoGameDBContext(DbContextOptions<VideoGameDBContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGameDetails => Set<VideoGameDetails>();

        // user auth tablewwwwwww
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Spider-Man 2",
                    Platform = "PS5",
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "The Legend of Zelda",
                    Platform = "Nintendo Switch",
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Cyberpunk 2077",
                    Platform = "PC",
                }
            );
        }
    }
}
