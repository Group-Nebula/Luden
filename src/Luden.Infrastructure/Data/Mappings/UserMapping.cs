using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Primary Key
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            //Properties
            builder.Property(u => u.Username).HasColumnType("varchar(50)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("varchar(150)").IsRequired();
            builder.Property(u => u.Password).HasColumnType("varchar(max)").IsRequired();

            //Base Entity Properties
            builder.Property(c => c.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()").IsRowVersion();
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);

            //Relationships
            builder.HasMany(u => u.Characters).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(u => u.Rpgs).WithOne(r => r.Master).HasForeignKey(r => r.MasterId);
            builder.HasMany(u => u.RpgPlayers).WithOne(rp => rp.Player).HasForeignKey(rp => rp.PlayerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
