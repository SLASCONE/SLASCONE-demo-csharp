using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class AnalyticalHeartbeat
    {
        [DataMember]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("analytical_heartbeat")]
        public List<AnalyticalFieldValue> Heartbeat { get; set; }

        [DataMember]
        [JsonProperty("token_key")]
        public string TokenKey { get; set; } = null;
    }
}
