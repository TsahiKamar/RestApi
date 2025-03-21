namespace RestApi.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
