using System.Collections.Generic;

namespace Slascone.Provisioning.Sample.Model
{
    public class AnalyticalHeartbeat
    {
        public string UniqueDeviceId { get; set; }
        public List<AnalyticalFieldValue> AnalyticalHeartbeatInfo { get; set; }
        public string DeviceLicenseKey { get; set; } = null;
    }
}
