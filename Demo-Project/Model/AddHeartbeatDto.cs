using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class AddHeartbeatDto
    {
        [DataMember]
        [Required]
        [JsonProperty("product-id")]
        public Guid ProductId { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("client-id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("software-version")]
        public string SoftwareVersion { get; set; }

        [DataMember]
        [JsonProperty("operating-system")]
        public string OperatingSystem { get; set; }

        [DataMember]
        [JsonProperty("token-key")]
        public string TokenKey { get; set; }

        [DataMember]
        [JsonProperty("group-id")]
        public string GroupId { get; set; }

        [DataMember]
        [JsonProperty("heartbeat-type-id")]
        public Guid? HeartbeatTypeId { get; set; }
    }
}
