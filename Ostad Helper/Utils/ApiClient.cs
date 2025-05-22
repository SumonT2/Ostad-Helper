using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ostad_Helper.Utils
{
    public class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var context = _httpContextAccessor.HttpContext;
            var token = context.Request.Cookies["AccessToken"];

            if (string.IsNullOrEmpty(token))
            {
                // Log: Missing token
                System.Diagnostics.Debug.WriteLine($"No AccessToken found for URL: {url}");
                context.Response.Redirect("/Token/Enter");
                return null;
            }

            // Clear previous headers to avoid conflicts
            _client.DefaultRequestHeaders.Remove("accesstoken");
            _client.DefaultRequestHeaders.Add("accesstoken", token);

            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Log the error for debugging
                System.Diagnostics.Debug.WriteLine($"API call to {url} failed with status: {response.StatusCode}");
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    context.Response.Redirect("/Token/Enter");
                    return null;
                }
                // Return the response for other errors (e.g., 429, 500) to let the caller handle it
                return response;
            }

            return response;
        }
    }
}