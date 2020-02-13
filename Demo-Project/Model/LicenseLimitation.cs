using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseLimitation
    {
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
