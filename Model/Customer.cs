using System;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class Customer
    {
        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty("isvId")]
        public Guid IsvId { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("customerNumber")]
        public string CustomerNumber { get; set; }
    }
}
