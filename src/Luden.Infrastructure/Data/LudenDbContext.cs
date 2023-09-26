using Luden.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Luden.Infrastructure.Data
{
    public class LudenDbContext : IdentityDbContext
    {
        public LudenDbContext(DbContextOptions<LudenDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<RPGSystem> Systems { get; set; }
        public DbSet<RPG> RPGs { get; set; }
        public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
        public DbSet<Character> Characters { get; set; }

    }
}
