using Luden.Domain.Entities;
using Luden.Domain.Enums;

namespace Luden.Application.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.UserName;
            Email = user.Email;
            Status = user.Status;
        }
    }
}