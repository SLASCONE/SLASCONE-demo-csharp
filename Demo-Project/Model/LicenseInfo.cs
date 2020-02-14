using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseInfo
    {
        [DataMember]
        [JsonProperty("license_key")]
        public string LicenseKey { get; set; }

        [DataMember]
        [JsonProperty("token_key")]
        public Guid? TokenKey { get; set; }

        [DataMember]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("is_license_valid")]
        public bool IsLicenseValid { get; set; }

        [DataMember]
        [JsonProperty("is_software_version_valid")]
        public bool IsSoftwareVersionValid { get; set; }

        [DataMember]
        [JsonProperty("expiration_date_utc")]
        public DateTime ExpirationDateUtc { get; set; }

        [DataMember]
        [JsonProperty("software_release_limitation")]
        public SoftwareReleaseLimitation SoftwareReleaseLimitation { get; set; }

        [DataMember]
        [JsonProperty("heartbeat_period")]
        public int? HeartBeatPeriod { get; set; }

        [DataMember]
        [JsonProperty("freeride")]
        public int? FreeRide { get; set; }

        [DataMember]
        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [DataMember]
        [JsonProperty("template_name")]
        public string TemplateName { get; set; }

        [DataMember]
        [JsonProperty("license_name")]
        public string LicenseName { get; set; }

        [DataMember]
        [JsonProperty("client_description")]
        public string ClientDescription { get; set; }

        [DataMember]
        [JsonProperty("enforce_software_version_upgrade")]
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
