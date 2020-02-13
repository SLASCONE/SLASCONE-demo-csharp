using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class AnalyticalFieldValue
    {
        [DataMember]
        [JsonProperty("analytical-field-id")]
        public Guid AnalyitcalFieldId { get; set; }

        [DataMember]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
