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
    }
}
