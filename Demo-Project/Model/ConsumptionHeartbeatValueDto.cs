using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class ConsumptionHeartbeatValueDto
    {
        [DataMember]
        [Required]
        [JsonProperty("limitation_id")]
        public Guid LimitationId { get; set; }

        [DataMember]
        [JsonProperty("timestamp_utc")]
        public DateTime? TimestampUtc { get; set; }

        [DataMember]
        [Required]
        [JsonProperty("value")]
        public Decimal Value { get; set; }
    }
}
