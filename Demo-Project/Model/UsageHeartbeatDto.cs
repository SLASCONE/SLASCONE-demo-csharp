using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class UsageHeartbeatDto
    {
        [DataMember]
        [JsonProperty("client-id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("usage-heartbeat")]
        public List<UsageHeartbeatValue> UsageHeartbeat { get; set; }

        [DataMember]
        [JsonProperty("token-key")]
        public string TokenKey { get; set; } = null;
    }
}
