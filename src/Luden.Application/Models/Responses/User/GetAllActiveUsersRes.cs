using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses.User
{
    public class GetAllActiveUsersRes
    {
        public IEnumerable<UserDTO> Data { get; set; }
    }
}
