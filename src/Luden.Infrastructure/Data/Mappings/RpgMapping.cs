using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgMapping : IEntityTypeConfiguration<Rpg>
    {
        public void Configure(EntityTypeBuilder<Rpg> builder)
        {
            //Primary Key
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            //Base Entity Properties
            builder.Property(c => c.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()").IsRowVersion();
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);

            //Properties
            builder.Property(r => r.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(r => r.Description).HasColumnType("varchar(max)").IsRequired();
            builder.Property(r => r.RpgDate).HasColumnType("datetime2").IsRequired();

            //Relationships
            builder.HasOne(r => r.Master).WithMany(u => u.Rpgs).HasForeignKey(r => r.MasterId);
            builder.HasOne(r => r.RpgSystem).WithMany(rs => rs.Rpgs).HasForeignKey(r => r.RpgSystemId);
            builder.HasMany(r => r.RpgSessions).WithOne(rs => rs.Rpg).HasForeignKey(rs => rs.RpgId);
            builder.HasMany(r => r.RpgPlayers).WithOne(rc => rc.Rpg).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
