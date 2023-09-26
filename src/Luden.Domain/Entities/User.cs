using Luden.Domain.Core.Models;
using Luden.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Luden.Domain.Entities
{
    public class User : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
