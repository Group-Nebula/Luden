using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgSystemMapping : IEntityTypeConfiguration<RpgSystem>
    {
        public void Configure(EntityTypeBuilder<RpgSystem> builder)
        {
            //Primary Key
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Id).ValueGeneratedOnAdd();

            //Base Entity Properties
            builder.Property(rs => rs.IsDeleted).HasDefaultValue(false);
            builder.Property(rs => rs.CreatedAt).HasColumnType("datetime2").ValueGeneratedOnAdd();
            builder.Property(rs => rs.UpdatedAt).HasColumnType("datetime2").ValueGeneratedOnAddOrUpdate();

            //Properties
            builder.Property(rs => rs.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(rs => rs.Description).HasColumnType("varchar(max)").IsRequired();
            builder.Property(rs => rs.Config).HasColumnType("varchar(max)").IsRequired();

            //Relationships
            builder.HasMany(rs => rs.Skills).WithOne(s => s.RpgSystem).HasForeignKey(s => s.RpgSystemId);
            builder.HasMany(rs => rs.Rpgs).WithOne(r => r.RpgSystem).HasForeignKey(r => r.RpgSystemId);
        }
    }
}
