using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgPlayerMapping : IEntityTypeConfiguration<RpgPlayer>
    {
        public void Configure(EntityTypeBuilder<RpgPlayer> builder)
        {
            //Primary Key
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.Id).ValueGeneratedOnAdd();

            //Relationships
            builder.HasOne(rp => rp.Rpg).WithMany(r => r.RpgPlayers).HasForeignKey(rs => rs.RpgId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(rp => rp.Player).WithMany(r => r.RpgPlayers).HasForeignKey(rs => rs.RpgId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
