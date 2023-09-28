using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class CharacterAttributeMapping : IEntityTypeConfiguration<CharacterAttribute>
    {
        public void Configure(EntityTypeBuilder<CharacterAttribute> builder)
        {
            throw new NotImplementedException();
        }
    }
}
