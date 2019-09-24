using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class LicenseInfo
    {
        [JsonProperty("licenseKey")]
        public string LicenseKey { get; set; }

        [JsonProperty("deviceLicenseKey")]
        public Guid? DeviceLicenseKey { get; set; }

        [JsonProperty("uniqueDeviceId")]
        public string UniqueDeviceId { get; set; }

        [JsonProperty("isLicenseValid")]
        public bool IsLicenseValid { get; set; }

        [JsonProperty("isSoftwareVersionValid")]
        public bool IsSoftwareVersionValid { get; set; }

        [JsonProperty("expirationDateUtc")]
        public DateTime ExpirationDateUtc { get; set; }

        [JsonProperty("softwareReleaseLimitation")]
        public SoftwareReleaseLimitation SoftwareReleaseLimitation { get; set; }

        [JsonProperty("heartBeatPeriod")]
        public int? HeartBeatPeriod { get; set; }

        [JsonProperty("freeRide")]
        public int? FreeRide { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("templateName")]
        public string TemplateName { get; set; }

        [JsonProperty("licenseName")]
        public string LicenseName { get; set; }

        [JsonProperty("deviceDescription")]
        public string DeviceDescription { get; set; }

        [JsonProperty("enforceSoftwareVersionUpgrade")]
        public bool EnforceSoftwareVersionUpgrade { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; } = new Customer();

        [JsonProperty("features")]
        public IList<LicenseFeature> Features { get; set; } = new List<LicenseFeature>();

        [JsonProperty("limitations")]
        public IList<LicenseLimitation> Limitations { get; set; } = new List<LicenseLimitation>();

        [JsonProperty("variables")]
        public IList<LicenseVariable> Variables { get; set; } = new List<LicenseVariable>();
    }
}
