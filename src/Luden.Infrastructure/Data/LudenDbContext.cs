using Luden.Domain.Entities;
using Luden.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Luden.Infrastructure.Data
{
    public class LudenDbContext : DbContext
    {
        public LudenDbContext(DbContextOptions<LudenDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<RpgSystem> RpgSystems { get; set; }
        public DbSet<Rpg> Rpgs { get; set; }
        public DbSet<RpgPlayer> RpgPlayers { get; set; }
        public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
        public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<RpgSession> RpgSessions { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mappings
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RpgSystemMapping());
            modelBuilder.ApplyConfiguration(new RpgMapping());
            modelBuilder.ApplyConfiguration(new RpgPlayerMapping());
            modelBuilder.ApplyConfiguration(new AttributeMapping());
            modelBuilder.ApplyConfiguration(new CharacterAttributeMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
            modelBuilder.ApplyConfiguration(new RpgSessionMapping());
            modelBuilder.ApplyConfiguration(new SessionMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

}
