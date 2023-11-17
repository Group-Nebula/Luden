using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Requests.RpgSystem
{
    public class CreateRpgSystemReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RpgSystemConfigDTO Config { get; set; }
        public IEnumerable<string> Skills { get; set; }
    }
}
