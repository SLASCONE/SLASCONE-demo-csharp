using System;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class SoftwareReleaseLimitation
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("softwareRelease")]
        public string SoftwareRelease { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
