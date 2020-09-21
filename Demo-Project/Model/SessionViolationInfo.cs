using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class SessionViolationInfo
    {
        [DataMember]
        [JsonProperty("is_session_valid")]
        public bool IsSessionValid { get; set; }

        [DataMember]
        [JsonProperty("session_valid_until")]
        public DateTime? SessionValidUntil { get; set; }
    }
}
