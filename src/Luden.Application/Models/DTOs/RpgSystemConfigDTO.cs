using Newtonsoft.Json;

namespace Luden.Application.Models.DTOs
{
    public class RpgSystemConfigDTO
    {
        public string SkillDice { get; set; }
        public string ToJson() => JsonConvert.SerializeObject(this);
        public static RpgSystemConfigDTO FromJson(string json) => JsonConvert.DeserializeObject<RpgSystemConfigDTO>(json) ?? new();
    }
}
