using System.IdentityModel.Tokens.Jwt;

namespace Ostad_Helper.Utils
{
    public class JwtDecodeMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtDecodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["accesstoken"];
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                var name = jwt.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                var exp = jwt.ValidTo;
                var avatar = jwt.Claims.FirstOrDefault(c => c.Type == "avatar_url")?.Value;


                context.Items["JwtName"] = name;
                context.Items["JwtExpiry"] = exp;
                context.Items["JwtAvatar"] = avatar;

            }

            await _next(context);
        }
    }

}
