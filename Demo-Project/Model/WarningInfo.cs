using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class WarningInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
