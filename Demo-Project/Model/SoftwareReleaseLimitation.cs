using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class SoftwareReleaseLimitation
    {
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [DataMember]
        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        [DataMember]
        [JsonProperty("software_release")]
        public string SoftwareRelease { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
