using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class ConsumptionHeartbeatDto
    {
        [DataMember]
        [Required]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("consumption_heartbeat")]
        public List<ConsumptionHeartbeatValueDto> ConsumptionHeartbeat { get; set; }

        [DataMember]
        [JsonProperty("token_key")]
        public Guid? TokenKey { get; set; }
    }
}
