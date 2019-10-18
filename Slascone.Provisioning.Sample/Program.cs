using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Slascone.Provisioning.Sample.Model;

namespace Slascone.Provisioning.Sample
{
    class Program
    {
        static async Task StartSampleAsync()
        {
            
        }

        // ToDo: Insert the parameter for the respective function
        static async Task Main()
        {
            StartSampleAsync().GetAwaiter().GetResult();

            var slasconeProxy = new SampleProxy();

            // ToDo
            var activatedLicense = await slasconeProxy.ActivateAsync("", "",
                "", "", "");

            if (activatedLicense.LicenseInfo == null)
            {
                Console.WriteLine(activatedLicense.WarningInfo.ErrorMessage);
            }
            else
            {
                Console.WriteLine("Successfully activated license.");
            }

            // ToDo
            var heartbeatResult = await slasconeProxy.AddHeartbeatAsync("", "",
                "", "", "");

            if (heartbeatResult.LicenseInfo == null)
            {
                Console.WriteLine(heartbeatResult.WarningInfo.ErrorMessage);
            }
            else
            {
                Console.WriteLine("Successfully created heartbeat.");
            }

            // ToDo
            var analyticalHb = new AnalyticalHeartbeat();
            analyticalHb.AnalyticalHeartbeatInfo = new List<AnalyticalFieldValue>();
            analyticalHb.DeviceLicenseKey = "";
            analyticalHb.UniqueDeviceId = "";

            var analyticalHeartbeatResult = await slasconeProxy.AddAnalyticalHeartbeatAsync(analyticalHb);

            Console.WriteLine(analyticalHeartbeatResult);
            
            if (activatedLicense.LicenseInfo != null)
            {
                // ToDo
                var unassignResult = await slasconeProxy.UnassignAsync(activatedLicense.LicenseInfo.DeviceLicenseKey.ToString());

                Console.WriteLine(unassignResult);
            }
        }
    }
}
