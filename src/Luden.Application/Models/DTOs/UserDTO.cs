using Luden.Domain.Entities;

namespace Luden.Application.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Username;
            Email = user.Email;
        }
    }
}