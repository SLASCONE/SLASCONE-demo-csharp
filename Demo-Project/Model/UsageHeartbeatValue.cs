using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class UsageHeartbeatValue
    {
        [DataMember]
        [JsonProperty("usage-feature-id")]
        public Guid UsageFeatureId { get; set; }

        [DataMember]
        [JsonProperty("usage-module-id")]
        public Guid? UsageModuleId { get; set; }

        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
