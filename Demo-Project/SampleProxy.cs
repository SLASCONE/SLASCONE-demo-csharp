using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Management;
using System.Net.Http;
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
        /// <returns>ProvisioningInfo where LicenseInfoDto or WarningInfoDto is set.</returns>
        public async Task<ProvisioningInfo> ActivateAsync(ActivateClientDto activateClientDto)
        { 
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/activations",
            };

            var bodyJson = JsonConvert.SerializeObject(activateClientDto);
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
        /// <returns>ProvisioningInfo where LicenseInfoDto or WarningInfoDto is set.</returns>
        public async Task<ProvisioningInfo> AddHeartbeatAsync(AddHeartbeatDto heartbeatDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"/api/v2/isv/{IsvId}/provisioning/heartbeats",
            };

            var bodyJson = JsonConvert.SerializeObject(heartbeatDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
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
                    $"/api/v2/isv/{IsvId}/data-gathering/analytical-heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(analyticalHeartbeat);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
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
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Creates a usage heartbeat
        /// </summary>
        /// <param name="usageHeartbeatDto">Is the object which contains all usage Heartbeat Information.</param>
        /// <returns>"Successfully created usage heartbeat." or a WarningInfoDto</returns>
        public async Task<string> AddUsageHeartbeat(UsageHeartbeatDto usageHeartbeatDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"/api/v2/isv/{IsvId}/data-gathering/usage-heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(usageHeartbeatDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
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
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Unassign a activated license.
        /// </summary>
        /// <returns>"Successfully deactivated License." or a WarningInfoDto</returns>
        public async Task<string> UnassignAsync(UnassignDto unassignDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/unassign",
            };

            var bodyJson = JsonConvert.SerializeObject(unassignDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
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
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Get the license info
        /// </summary>
        /// <returns>LicenseInfo</returns>
        public async Task<LicenseInfo> GetLicenseInfo(ValidateLicenseDto validateLicenseDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/validate",
            };

            var bodyJson = JsonConvert.SerializeObject(validateLicenseDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

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
