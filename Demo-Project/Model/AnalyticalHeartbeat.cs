using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class AnalyticalHeartbeat
    {
        [DataMember]
        [JsonProperty("client-id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("analytical-heartbeat")]
        public List<AnalyticalFieldValue> Heartbeat { get; set; }

        [DataMember]
        [JsonProperty("token-key")]
        public string TokenKey { get; set; } = null;
    }
}
