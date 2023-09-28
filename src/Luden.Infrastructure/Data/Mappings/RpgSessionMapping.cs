using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    internal class RpgSessionMapping : IEntityTypeConfiguration<RpgSession>
    {
        public void Configure(EntityTypeBuilder<RpgSession> builder)
        {
            throw new NotImplementedException();
        }
    }
}
