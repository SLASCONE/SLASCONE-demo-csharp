using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class SessionDto
    {
        [DataMember]
        [Required]
        [JsonProperty("license_id")]
        public Guid LicenseId { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}
