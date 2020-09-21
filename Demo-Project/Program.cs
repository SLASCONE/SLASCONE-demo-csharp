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

            //ToDo: Fill the variables
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

            // If the activation failed, the api server responses with a specific error message which describes the problem. Therefore the LicenseInfo object is declared with null.
            if (activatedLicense.LicenseInfo == null)
            {
                Console.WriteLine(activatedLicense.WarningInfo.Message);
            }
            else
            {
                Console.WriteLine("Successfully activated license.");
            }

            // ToDo: Uncomment specific scenario
            //await HeartbeatSample(activatedLicense);
            //await FloatingLicensingSample(activatedLicense);

        }

        private static async Task FloatingLicensingSample(ProvisioningInfo activatedLicense)
        {
            var slasconeProxy = new SampleProxy();

            // ToDo: Fill the variables
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

            // If the heartbeat failed, the api server responses with a specific error message which describes the problem. Therefore the LicenseInfo object is declared with null.
            if (heartbeatResult.LicenseInfo == null)
            {
                Console.WriteLine(heartbeatResult.WarningInfo.Message);
            }
            else
            {
                // After successfully generating a heartbeat the client have to check provisioning mode of the license. Is it floating a session has to be opened. 
                if (heartbeatResult.LicenseInfo.ProvisioningMode == ProvisioningMode.Floating)
                {
                    // ToDo: Fill the variables
                    var sessionDto = new SessionDto
                    {
                        ClientId = "",
                        LicenseId = Guid.Parse("")
                    };

                    var openSessionResult = await slasconeProxy.OpenSession(sessionDto);

                    // If the floating limit is reached the api server responses with an Error.
                    if (openSessionResult.SessionViolationInfo == null)
                    {
                        Console.WriteLine(openSessionResult.WarningInfo.Message);
                    }
                    else
                    {
                        Console.WriteLine("Session active until: " + openSessionResult.SessionViolationInfo.SessionValidUntil);
                    }

                    // If the client have finished his work, he has to close the session. Therefore other clients are not blocked anymore and have not to wait until another Client expired. 
                    var closeSessionResult = await slasconeProxy.CloseSession(sessionDto);

                    Console.WriteLine(closeSessionResult);
                }
            }
        }

        private static async Task HeartbeatSample(ProvisioningInfo activatedLicense)
        {
            var slasconeProxy = new SampleProxy();

            // ToDo: Fill the variables
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

            // If the heartbeat failed, the api server responses with a specific error message which describes the problem. Therefore the LicenseInfo object is declared with null.
            if (heartbeatResult.LicenseInfo == null)
            {
                Console.WriteLine(heartbeatResult.WarningInfo.Message);
            }
            else
            {
                Console.WriteLine("Successfully created heartbeat.");
            }

            // ToDo: Fill the variables
            var analyticalHb = new AnalyticalHeartbeat();
            analyticalHb.Heartbeat = new List<AnalyticalFieldValue>();
            analyticalHb.ClientId = "";

            var analyticalHeartbeatResult = await slasconeProxy.AddAnalyticalHeartbeatAsync(analyticalHb);

            Console.WriteLine(analyticalHeartbeatResult);

            // ToDo: Fill the variables
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
                // ToDo: Fill the variables
                var unassignDto = new UnassignDto
                {
                    TokenKey = ""
                };

                var unassignResult = await slasconeProxy.UnassignAsync(unassignDto);

                Console.WriteLine(unassignResult);
            }

            // ToDo: Fill the variables
            var consumptionHeartbeat = new ConsumptionHeartbeatDto();
            consumptionHeartbeat.ClientId = "";
            consumptionHeartbeat.ConsumptionHeartbeat = new List<ConsumptionHeartbeatValueDto>();
            consumptionHeartbeat.TokenKey = Guid.Parse("");

            var consumptionHeartbeatValue1 = new ConsumptionHeartbeatValueDto();
            consumptionHeartbeatValue1.LimitationId = Guid.Parse("");
            consumptionHeartbeatValue1.Value = 1;
            consumptionHeartbeatValue1.LimitationId = Guid.Parse("");
            consumptionHeartbeat.ConsumptionHeartbeat.Add(consumptionHeartbeatValue1);

            var consumptionHeartbeatResult = await slasconeProxy.AddConsumptionHeartbeat(consumptionHeartbeat);

            Console.WriteLine(consumptionHeartbeatResult);

            var remainingConsumptions = await slasconeProxy.GetConsumptionStatus(new ValidateConsumptionStatusDto
            { LimitationId = Guid.Parse(""), ClientId = "" });
        }

    }
}
