using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class ActivateClientDto
    {
        [DataMember(Name = "product_id")]
        [JsonProperty("product_id")]
        public Guid? ProductId { get; set; }

        [DataMember(Name = "license_key")]
        [JsonProperty("license_key")]
        public string LicenseKey { get; set; }

        [DataMember(Name = "client_id")]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client_name")]
        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [DataMember(Name = "client_description")]
        [JsonProperty("client_description")]
        public string ClientDescription { get; set; }

        [DataMember(Name = "software_version")]
        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

    }
}
