namespace IdentityService.Infrastructure.Data.Options
{
    public class JwtOptions()
    {
        public const string JwtKey = "JWTBearer";
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
