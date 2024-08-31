using GamesBasePrototype.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesBasePrototype.API.Persistence
{
    public class GamesBaseDbContext : DbContext
    {
        public GamesBaseDbContext(DbContextOptions<GamesBaseDbContext> options) : base(options)
        {
        }

        public DbSet<GamesBase> GamesBase { get; set; }
        public DbSet<GamesBaseDev> GamesBaseDev { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GamesBase>(e =>
            {
                e.HasKey(de => de.Id);

                e.Property(de => de.Title).IsRequired(false);
                e.Property(de => de.Description)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                e.Property(de => de.AnnouncementDate)
                    .HasColumnName("Start_Date");

                e.Property(de => de.EndDate)
                    .HasColumnName("End_Date");

                e.HasMany(de => de.Devs)
                    .WithOne()
                    .HasForeignKey(d => d.GamesBaseId);
            });

            builder.Entity<GamesBaseDev>(e =>
            {
                e.HasKey(d => d.Id);
                e.Property(d => d.Name).IsRequired();
                e.Property(d => d.SteamProfile).IsRequired(false);
                e.HasOne<GamesBase>()
                    .WithMany(g => g.Devs)
                    .HasForeignKey(d => d.GamesBaseId);
            });
        }
    }
}
