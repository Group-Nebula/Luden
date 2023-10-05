using System.ComponentModel.DataAnnotations;

namespace Luden.Application.Models.Requests
{
    public class CreateUserReq
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
