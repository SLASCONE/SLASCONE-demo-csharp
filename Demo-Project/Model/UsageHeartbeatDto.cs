using System.Collections.Generic;

namespace Slascone.Provisioning.Sample.Model
{
    public class UsageHeartbeatDto
    {
        public string UniqueDeviceId { get; set; }
        public List<UsageFeatureValue> UsageHeartbeat { get; set; }
    }
}
