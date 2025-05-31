using Microsoft.AspNetCore.Mvc;
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
    }
}