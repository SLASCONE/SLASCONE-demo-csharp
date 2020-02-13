using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseFeature
    {
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
