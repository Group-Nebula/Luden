using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    internal class RpgSessionMapping : IEntityTypeConfiguration<RpgSession>
    {
        public void Configure(EntityTypeBuilder<RpgSession> builder)
        {
            //Primary Key
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Id).ValueGeneratedOnAdd();

            //Properties
            builder.Property(rs => rs.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(rs => rs.SessionNotes).HasColumnType("varchar(max)");
            builder.Property(rs => rs.SessionDate).HasColumnType("datetime2").IsRequired();

            //Base Entity Properties
            builder.Property(rs => rs.IsDeleted).HasDefaultValue(false);
            builder.Property(rs => rs.UpdatedAt).HasColumnType("datetime2").ValueGeneratedOnAddOrUpdate();
            builder.Property(rs => rs.CreatedAt).HasColumnType("datetime2").ValueGeneratedOnAdd();

            //Relationships
            builder.HasOne(rs => rs.Rpg).WithMany(r => r.RpgSessions).HasForeignKey(rs => rs.RpgId);
            builder.HasOne(rs => rs.Session).WithMany(s => s.RpgSessions).HasForeignKey(rs => rs.SessionId);
        }
    }
}
