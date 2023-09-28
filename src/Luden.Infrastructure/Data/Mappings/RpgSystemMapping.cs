using Luden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luden.Infrastructure.Data.Mappings
{
    public class RpgSystemMapping : IEntityTypeConfiguration<RpgSystem>
    {
        public void Configure(EntityTypeBuilder<RpgSystem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
