namespace Luden.Domain.Core.Models
{
    public interface IAuditableEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}