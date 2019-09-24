using System;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseVariable
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
