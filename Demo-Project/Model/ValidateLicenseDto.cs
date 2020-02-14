using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class ValidateLicenseDto
    {
        [DataMember]
        [Required]
        [JsonProperty("license_key")]
        public string LicenseKey { get; set; }
    }
}
