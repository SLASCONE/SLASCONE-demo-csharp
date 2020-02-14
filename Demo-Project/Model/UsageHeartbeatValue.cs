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
        [JsonProperty("usage_feature_id")]
        public Guid UsageFeatureId { get; set; }

        [DataMember]
        [JsonProperty("usage_module_id")]
        public Guid? UsageModuleId { get; set; }

        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
