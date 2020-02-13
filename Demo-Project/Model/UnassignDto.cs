using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Slascone.Provisioning.Sample.Model
{
    public class UnassignDto
    {
        [DataMember]
        [Required]
        [JsonProperty("token-key")]
        public string TokenKey { get; set; }
    }
}
