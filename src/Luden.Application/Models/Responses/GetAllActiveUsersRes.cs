using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses
{
    public class GetAllActiveUsersRes
    {
        public IEnumerable<UserDTO> Data { get; set; }
    }
}
