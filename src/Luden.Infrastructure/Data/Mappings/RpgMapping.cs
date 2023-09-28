using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgMapping : IEntityTypeConfiguration<Rpg>
    {
        public void Configure(EntityTypeBuilder<Rpg> builder)
        {
            throw new NotImplementedException();
        }
    }
}
