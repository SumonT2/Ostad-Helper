using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
namespace Ostad_Helper.Utils
{
    public class TokenController : Controller
    {
        [HttpGet]
        public IActionResult EnterToken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                Response.Cookies.Append("AccessToken", token, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    HttpOnly = true,
                    Secure = true // Requires HTTPS
                });

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Token cannot be empty.";
            return View();
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(string token)
        {
            token = string.Concat(token.Where(c => !char.IsWhiteSpace(c)));
            if (!string.IsNullOrWhiteSpace(token))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(token);

                    // Optional: Save to cookie (30 days)
                    Response.Cookies.Append("AccessToken", token.Trim(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30),
                        HttpOnly = true,
                        Secure = true
                    });

                    ViewBag.Token = token;
                    ViewBag.Claims = jwt.Claims
                        .ToDictionary(c => c.Type, c => c.Value);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Invalid JWT: " + ex.Message;
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Token cannot be empty.";
            return View();
        }
    }
}