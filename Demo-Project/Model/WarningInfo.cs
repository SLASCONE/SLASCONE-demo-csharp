using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class WarningInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
