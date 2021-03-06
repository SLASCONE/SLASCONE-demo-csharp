using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
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
        private const string SignatureKey = "";

        private readonly HttpClient _httpClient = new HttpClient();

        public SampleProxy()
        {
            _httpClient.DefaultRequestHeaders.Add("ProvisioningKey", ProvisioningKey);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }


        #region Activate/Unassign

        /// <summary>
        /// Activates a License
        /// </summary>
        /// <returns>ProvisioningInfo where LicenseInfoDto or WarningInfoDto is set.</returns>
        public async Task<ProvisioningInfo> ActivateAsync(ActivateClientDto activateClientDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/activations"
            };

            var bodyJson = JsonConvert.SerializeObject(activateClientDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

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


        /// <summary>
        /// Unassign a activated license.
        /// </summary>
        /// <returns>"Successfully deactivated License." or a WarningInfoDto</returns>
        public async Task<string> UnassignAsync(UnassignDto unassignDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/unassign"
            };

            var bodyJson = JsonConvert.SerializeObject(unassignDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            // If unassign was successful, the api returns a status code Ok(200)".
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

        #endregion

        #region Heartbeats(Normal,Analytical,Usage)

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
                    $"/api/v2/isv/{IsvId}/provisioning/heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(heartbeatDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

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
                    $"/api/v2/isv/{IsvId}/data_gathering/analytical_heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(analyticalHeartbeat);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

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
                    $"/api/v2/isv/{IsvId}/data_gathering/usage_heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(usageHeartbeatDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            // If generating a usage heartbeat was successful, the api returns a status code Ok(200) with the message "Successfully created usage heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
            // If generating a usage heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        #endregion

        #region Consumption Mode

        /// <summary>
        /// Creates a consumption heartbeat
        /// </summary>
        /// <param name="consumptionHeartbeatDtoDto">Is the object which contains all consumption Heartbeat Information.</param>
        /// <returns>"Successfully created consumption heartbeat." or a WarningInfoDto</returns>
        public async Task<string> AddConsumptionHeartbeat(ConsumptionHeartbeatDto consumptionHeartbeatDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path =
                    $"/api/v2/isv/{IsvId}/data_gathering/consumption_heartbeats"
            };

            var bodyJson = JsonConvert.SerializeObject(consumptionHeartbeatDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            // If generating a consumption heartbeat was successful, the api returns a status code Ok(200) with the message "Successfully created consumption heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
            // If generating a usage heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Get the consumption status of an limitation per assignment
        /// </summary>
        /// <returns>Remaining Consumption Value</returns>
        public async Task<string> GetConsumptionStatus(ValidateConsumptionStatusDto validateConsumptionDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/validate/consumption"
            };

            var bodyJson = JsonConvert.SerializeObject(validateConsumptionDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }

            throw new Exception(response.StatusCode.ToString());
        }


        #endregion

        #region Floating Licensing

        /// <summary>
        /// Opens a session
        /// </summary>
        /// <param name="sessionDto">Is the object which contains all information to open a session.</param>
        /// <returns>SessionInfo</returns>
        public async Task<SessionInfo> OpenSession(SessionDto sessionDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/session/open"
            };

            var bodyJson = JsonConvert.SerializeObject(sessionDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            // If activation was successful, the api returns a status code Ok(200) with the information of the license.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var resultSessionInfo = new SessionInfo();
                resultSessionInfo.WarningInfo = null;
                resultSessionInfo.SessionViolationInfo = JsonConvert.DeserializeObject<SessionViolationInfo>(content);
                return resultSessionInfo;
            }

            // If activation was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var resultSessionInfo = new SessionInfo();
                resultSessionInfo.WarningInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                resultSessionInfo.SessionViolationInfo = null;
                return resultSessionInfo;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        /// <summary>
        /// Opens a session
        /// </summary>
        /// <param name="sessionDto">Is the object which contains all information to close a session.</param>
        /// <returns>"Success." or a WarningInfoDto</returns>
        public async Task<string> CloseSession(SessionDto sessionDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/session/close"
            };
            var bodyJson = JsonConvert.SerializeObject(sessionDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri.Uri, body);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

            // If generating a consumption heartbeat was successful, the api returns a status code Ok(200) with the message "Successfully created consumption heartbeat.".
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
            // If generating a usage heartbeat was unsuccessful, the api returns a status code Conflict(409) with the information of a warning.
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                var errorInfo = JsonConvert.DeserializeObject<WarningInfo>(content);
                return errorInfo.Message;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        #endregion


        /// <summary>
        /// Get the license info
        /// </summary>
        /// <returns>LicenseInfo</returns>
        public async Task<LicenseInfo> GetLicenseInfo(ValidateLicenseDto validateLicenseDto)
        {
            var uri = new UriBuilder(ApiBaseUrl)
            {
                Path = $"/api/v2/isv/{IsvId}/provisioning/validate"
            };

            var bodyJson = JsonConvert.SerializeObject(validateLicenseDto);
            var body = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri.Uri,
                Content = body
            };

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!await IsSignatureValid(response))
            {
                throw new Exception("Signature is not valid!.");
            }

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

        /// <summary>
        /// Validates the authority by signature
        /// </summary>
        /// <returns>True if Signature is valid. False if Signature is invalid.</returns>
        private async Task<bool> IsSignatureValid(HttpResponseMessage response)
        {
            var responseStream = await response.Content.ReadAsByteArrayAsync();

            var hmac = new HMACSHA256();
            hmac.Key = Encoding.UTF8.GetBytes(SignatureKey);

            var hash = hmac.ComputeHash(responseStream);
            var hashString = BitConverter.ToString(hash).Replace("-", "");

            if (response.Headers.GetValues("x-slascone-signature").FirstOrDefault().Equals(hashString))
            {
                return true;
            }

            return false;

        }
    }
}
