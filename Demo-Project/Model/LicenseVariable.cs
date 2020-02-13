using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseVariable
    {
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
