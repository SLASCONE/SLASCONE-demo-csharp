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
        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [DataMember]
        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }

        [DataMember]
        [JsonProperty("token_key")]
        public string TokenKey { get; set; }

        [DataMember]
        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [DataMember]
        [JsonProperty("heartbeat_type_id")]
        public Guid? HeartbeatTypeId { get; set; }
    }
}
