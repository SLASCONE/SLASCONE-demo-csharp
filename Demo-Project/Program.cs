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

            //ToDo
            var activateClientDto = new ActivateClientDto
            {
                ClientDescription = "",
                ClientId = "",
                ClientName = "",
                LicenseKey = "",
                ProductId = Guid.Parse(""),
                SoftwareVersion = ""
            };

            var activatedLicense = await slasconeProxy.ActivateAsync(activateClientDto);

            if (activatedLicense.LicenseInfo == null)
            {
                Console.WriteLine(activatedLicense.WarningInfo.Message);
            }
            else
            {
                Console.WriteLine("Successfully activated license.");
            }

            // ToDo
            var heartbeatDto = new AddHeartbeatDto
            {
                TokenKey = "",
                ProductId = Guid.Parse(""),
                ClientId = "",
                SoftwareVersion = "",
                GroupId = "",
                HeartbeatTypeId = Guid.Parse(""),
                OperatingSystem = ""
            };

            var heartbeatResult = await slasconeProxy.AddHeartbeatAsync(heartbeatDto);

            if (heartbeatResult.LicenseInfo == null)
            {
                Console.WriteLine(heartbeatResult.WarningInfo.Message);
            }
            else
            {
                Console.WriteLine("Successfully created heartbeat.");
            }

            // ToDo
            var analyticalHb = new AnalyticalHeartbeat();
            analyticalHb.Heartbeat = new List<AnalyticalFieldValue>();
            analyticalHb.ClientId = "";

            var analyticalHeartbeatResult = await slasconeProxy.AddAnalyticalHeartbeatAsync(analyticalHb);

            Console.WriteLine(analyticalHeartbeatResult);

            // ToDo
            var usageHeartbeat = new UsageHeartbeatDto();
            usageHeartbeat.UsageHeartbeat = new List<UsageHeartbeatValue>();
            usageHeartbeat.ClientId = "";

            var usageFeatureValue1 = new UsageHeartbeatValue();
            usageFeatureValue1.UsageFeatureId = Guid.Parse("");
            usageFeatureValue1.Value = "";

            var usageFeatureValue2 = new UsageHeartbeatValue();
            usageFeatureValue2.UsageFeatureId = Guid.Parse("");
            usageFeatureValue2.Value = "";
            usageHeartbeat.UsageHeartbeat.Add(usageFeatureValue1);
            usageHeartbeat.UsageHeartbeat.Add(usageFeatureValue2);

            var usageHeartbeatResult = await slasconeProxy.AddUsageHeartbeat(usageHeartbeat);

            Console.WriteLine(usageHeartbeatResult);


            if (activatedLicense.LicenseInfo != null)
            {
                // ToDo
                var unassignDto = new UnassignDto
                {
                    TokenKey = ""
                };

                var unassignResult = await slasconeProxy.UnassignAsync(unassignDto);

                Console.WriteLine(unassignResult);
            }
        }
    }
}
