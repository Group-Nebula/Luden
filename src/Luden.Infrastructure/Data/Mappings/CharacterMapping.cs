using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class CharacterMapping : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            //Primary Key
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            //Base Entity Properties
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()").IsRowVersion();

            //Properties
            builder.Property(c => c.Name).HasColumnType("varchar(150)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("varchar(max)").IsRequired();
            builder.Property(c => c.ImageUrl).HasColumnType("varchar(max)").IsRequired();
            builder.Property(c => c.BirthDate).HasColumnType("datetime2").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int").IsRequired();

            //Relationships
            builder.HasOne(c => c.User).WithMany(u => u.Characters).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.CharacterSkills).WithOne(cs => cs.Character).HasForeignKey(c => c.CharacterId);
        }
    }
}
