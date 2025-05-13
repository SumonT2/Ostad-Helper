using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Ostad_Helper.Utils
{
    public class ApiClient
    {
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
                context.Response.Redirect("/Token/Enter");
                return null;
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("accesstoken", token);

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                context.Response.Redirect("/Token/Enter");
                return null;
            }

            return response;
        }

        // You can add PostAsync, PutAsync, DeleteAsync in a similar way
    }
}





