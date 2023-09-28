using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgPlayerMapping : IEntityTypeConfiguration<RpgPlayer>
    {
        public void Configure(EntityTypeBuilder<RpgPlayer> builder)
        {
            throw new NotImplementedException();
        }
    }
}
