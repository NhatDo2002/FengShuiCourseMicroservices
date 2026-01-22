namespace IdentityService.API.Services
{
    public class AuthCookieWriter(
            IHttpContextAccessor httpContextAccessor
        )
        : IAuthCookieWriter 
    {
        public void WriteAuthToken(string cookieName, string token, DateTime? expiredAtUtc)
        {
            httpContextAccessor.HttpContext!.Response.Cookies.Append(cookieName, token, new CookieOptions
            {
                HttpOnly = true,
                Expires = expiredAtUtc,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }
    }
}
