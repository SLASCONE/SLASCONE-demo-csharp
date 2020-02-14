using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class UsageHeartbeatDto
    {
        [DataMember]
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [DataMember]
        [JsonProperty("usage_heartbeat")]
        public List<UsageHeartbeatValue> UsageHeartbeat { get; set; }

        [DataMember]
        [JsonProperty("token_key")]
        public string TokenKey { get; set; } = null;
    }
}
