using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SecurityTokenController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityTokenController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SecurityTokenController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetSecurityTokenAsync()
        {
            try
            {
                // API endpoint URL
                string apiUrl = "https://preprodservice.utilipay.co.za/api/SecurityToken";

                // Parameters
                string username = "apiuser@sebata.co.za";
                string password = "Password1!";

                // Constructing the URL with parameters
                string requestUrl = $"{apiUrl}?username={username}&password={password}";

                // Sending GET request
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string token = await response.Content.ReadAsStringAsync();
                    return Ok(token); // Return the token
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
