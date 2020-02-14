using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class Customer
    {
        [DataMember]
        [JsonProperty("customer_id")]
        public Guid CustomerId { get; set; }

        [DataMember]
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [DataMember]
        [JsonProperty("customer_number")]
        public string CustomerNumber { get; set; }
    }
}
