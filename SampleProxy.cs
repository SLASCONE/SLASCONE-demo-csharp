using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Management;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Slascone.Provisioning.Sample.Model;


namespace Slascone.Provisioning.Sample
{
    /// <summary>
    /// Proxy for Slascone Provisioning
    /// </summary>
    public class SampleProxy
    {
        // ToDo: Exchange the value of the variables to your specific tenant.

        private const string ApiBaseUrl = "https://api.slascone.com";
        private const string ProvisioningKey = "";
        private const string IsvId = "";

        private readonly HttpClient _httpClient = new HttpClient();

        public SampleProxy()
        {
            _httpClient.DefaultRequestHeaders.Add("ProvisioningKey", ProvisioningKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
 
        /// <summary>
        /// Activates a License
        /// </summary>
        /// <param name="productId">Specifies the product which the license is aligned.</param>
        /// <param name="deviceLicenseKey">Can be a DeviceLicenseKey, LicenseKey or LegacyLicenseKey.</param>
        /// <param name="uniqueDeviceId">Is the id which identifies the device.</param>
        /// <param name="deviceName">Is the name of a device.</param>
        /// <param name="deviceDescription">Is a description for a device.</param>
        /// <returns>ProvisioningInfo where LicenseInfoDto or WarningInfoDto is set.</returns>
        public async Task<ProvisioningInfo> ActivateAsync(string productId, string deviceLicenseKey, string uniqueDeviceId,
            string deviceName, string deviceDescription)
        { 
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"api/Provisioning/{IsvId}/devicelicense/activate",
            };

            var bodyData = new
            {
                productId,
                deviceLicenseKey,
                uniqueDeviceId,
                deviceName,
                deviceDescription,
            };

            var bodyJson = JsonConvert.SerializeObject(bodyData);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            // If activation was successful, the api returns a status code Ok(200) with the information of the license.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resultProvisioningInfo = new ProvisioningInfo();
                resultProvisioningInfo.WarningInfo = null;
                resultProvisioningInfo.LicenseInfo = JsonConvert.DeserializeObject<LicenseInfo>(content);
                return resultProvisioningInfo;
            }

            // If activation was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var resultProvisioningInfo = new ProvisioningInfo();
                resultProvisioningInfo.WarningInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                resultProvisioningInfo.LicenseInfo = null;
                return resultProvisioningInfo;
            }

            throw new Exception(response.StatusCode.ToString());
        }


        // Creates a heartbeat
        // Response is either a LicenseInfoDto or a WarningInfoDto
        /// <summary>
        /// Creates a heartbeat
        /// </summary>
        /// <param name="productId">Specifies the product which the license is aligned.</param>
        /// <param name="deviceLicenseKey">Can be a DeviceLicenseKey, LicenseKey or LegacyLicenseKey.</param>
        /// <param name="softwareVersion">Is the software version which the license is currently assigned.</param>
        /// <param name="operatingSystem">Is the operating system on which the license is currently assigned.</param>
        /// <param name="uniqueDeviceId">Is the id which identifies the device.</param>
        /// <returns>ProvisioningInfo where LicenseInfoDto or WarningInfoDto is set.</returns>
        public async Task<ProvisioningInfo> AddHeartbeatAsync(string productId, string deviceLicenseKey, string softwareVersion, string operatingSystem,
            string uniqueDeviceId)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"api/Provisioning/isv/{IsvId}/productId/{productId}/softwareversion/{softwareVersion}/os/{operatingSystem}/deviceId/{uniqueDeviceId}",
            };

            var response = await _httpClient.PostAsync(uri.Uri, null);
            var content = await response.Content.ReadAsStringAsync();
            
            // If generating a heartbeat was successful, the api returns a status code Ok(200) with the information of the license.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resultProvisioningInfo = new ProvisioningInfo();
                resultProvisioningInfo.WarningInfo = null;
                resultProvisioningInfo.LicenseInfo = JsonConvert.DeserializeObject<LicenseInfo>(content);
                return resultProvisioningInfo;
            }

            // If generating a heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var resultProvisioningInfo = new ProvisioningInfo();
                resultProvisioningInfo.WarningInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                resultProvisioningInfo.LicenseInfo = null;
                return resultProvisioningInfo;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Creates a analytical heartbeat
        /// </summary>
        /// <param name="analyticalHeartbeat">Is the object which contains all analytical Heartbeat Information.</param>
        /// <returns>"Successfully created analytical heartbeat." or a WarningInfoDto</returns>
        public async Task<string> AddAnalyticalHeartbeatAsync(AnalyticalHeartbeat analyticalHeartbeat)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"api/ProductAnalytics/isv/{IsvId}/analyticalHeartbeat"
            };

            var response = await _httpClient.PostAsync(uri.Uri, analyticalHeartbeat, new JsonMediaTypeFormatter());
            var content = await response.Content.ReadAsStringAsync();

            // If generating a analytical heartbeat was successful, the api returns a status code Ok(200) with the message "Successfully created analytical heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
            // If generating a analytical heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.ErrorMessage;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<string> AddUsageHeartbeat(UsageHeartbeatDto usageHeartbeatDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"api/ProductAnalytics/isv/{IsvId}/usageHeartbeat"
            };

            var response = await _httpClient.PostAsync(uri.Uri, usageHeartbeatDto, new JsonMediaTypeFormatter());
            var content = await response.Content.ReadAsStringAsync();

            // If generating a analytical heartbeat was successful, the api returns a status code Ok(200) with the message "Successfully created analytical heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
            // If generating a analytical heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.ErrorMessage;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Unassign a activated license.
        /// </summary>
        /// <param name="deviceLicenseKey">Is the key of the license assignment which you want to unassign.</param>
        /// <returns>"Successfully deactivated License." or a WarningInfoDto</returns>
        public async Task<string> UnassignAsync(string deviceLicenseKey)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"api/Provisioning/{IsvId}/devicelicensekey/{deviceLicenseKey}/unassign",
            };

            var response = await _httpClient.PostAsync(uri.Uri, null);
            var content = await response.Content.ReadAsStringAsync();

            // If unassign was successful, the api returns a status code Ok(200) with the message "Successfully created analytical heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }

            // If unassign was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.ErrorMessage;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Get the license info
        /// </summary>
        /// <param name="deviceLicenseKey">Is the key of the license assignment where you want to get the depending license information.</param>
        /// <returns>LicenseInfo</returns>
        public LicenseInfo GetLicenseInfo(string deviceLicenseKey)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"api/Provisioning/isv/{IsvId}/devicelicensekey/{deviceLicenseKey}",
            };

            var response = _httpClient.GetAsync(uri.Uri).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<LicenseInfo>(content);
            }
            
            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Get a unique device id based on the system
        /// </summary>
        /// <returns>UUID via string</returns>
        public string GetUniqueDeviceId()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct"))
            {
                var shares = searcher.Get();
                var props = shares.Cast<ManagementObject>().First().Properties;
                var uuid = props["UUID"].Value as string;

                return uuid;
            }
        }
    }
}
