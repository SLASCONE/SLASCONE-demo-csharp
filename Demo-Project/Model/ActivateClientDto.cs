using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class ActivateClientDto
    {
        [DataMember(Name = "product-id")]
        [JsonProperty("product-id")]
        public Guid? ProductId { get; set; }

        [DataMember(Name = "license-key")]
        [JsonProperty("license-key")]
        public string LicenseKey { get; set; }

        [DataMember(Name = "client-id")]
        [JsonProperty("client-id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client-name")]
        [JsonProperty("client-name")]
        public string ClientName { get; set; }

        [DataMember(Name = "client-description")]
        [JsonProperty("client-description")]
        public string ClientDescription { get; set; }

        [DataMember(Name = "software-version")]
        [JsonProperty("software-version")]
        public string SoftwareVersion { get; set; }

    }
}
