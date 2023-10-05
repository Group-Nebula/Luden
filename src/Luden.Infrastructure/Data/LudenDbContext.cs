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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
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
            modelBuilder.ApplyConfiguration(new SkillMapping());
            modelBuilder.ApplyConfiguration(new CharacterSkillMapping());
            modelBuilder.ApplyConfiguration(new CharacterMapping());
            modelBuilder.ApplyConfiguration(new RpgSessionMapping());
            modelBuilder.ApplyConfiguration(new SessionMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
