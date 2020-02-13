using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseInfo
    {
        [DataMember]
        [JsonProperty("license-key")]
        public string LicenseKey { get; set; }

        [DataMember]
        [JsonProperty("token-key")]
        public Guid? TokenKey { get; set; }

        [DataMember]
        [JsonProperty("client-id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("is-license-valid")]
        public bool IsLicenseValid { get; set; }

        [DataMember]
        [JsonProperty("is-software-version-valid")]
        public bool IsSoftwareVersionValid { get; set; }

        [DataMember]
        [JsonProperty("expiration-date-utc")]
        public DateTime ExpirationDateUtc { get; set; }

        [DataMember]
        [JsonProperty("software-release-limitation")]
        public SoftwareReleaseLimitation SoftwareReleaseLimitation { get; set; }

        [DataMember]
        [JsonProperty("heartbeat-period")]
        public int? HeartBeatPeriod { get; set; }

        [DataMember]
        [JsonProperty("freeride")]
        public int? FreeRide { get; set; }

        [DataMember]
        [JsonProperty("product-name")]
        public string ProductName { get; set; }

        [DataMember]
        [JsonProperty("template-name")]
        public string TemplateName { get; set; }

        [DataMember]
        [JsonProperty("license-name")]
        public string LicenseName { get; set; }

        [DataMember]
        [JsonProperty("client-description")]
        public string ClientDescription { get; set; }

        [DataMember]
        [JsonProperty("enforce-software-version-upgrade")]
        public bool EnforceSoftwareVersionUpgrade { get; set; }

        [DataMember]
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [DataMember]
        [JsonProperty("features")]
        public List<LicenseFeature> Features { get; set; } = new List<LicenseFeature>();

        [DataMember]
        [JsonProperty("limitations")]
        public List<LicenseLimitation> Limitations { get; set; } = new List<LicenseLimitation>();

        [DataMember]
        [JsonProperty("variables")]
        public List<LicenseVariable> Variables { get; set; } = new List<LicenseVariable>();
    }
}
