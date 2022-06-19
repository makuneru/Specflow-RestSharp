using Newtonsoft.Json;
namespace SmooveAPI
{
    public partial class TokenDetails
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("tokenUrl")]
        public string TokenUrl { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("not_before")]
        public long NotBefore { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("expires_on")]
        public long ExpiresOn { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("profile_info")]
        public string ProfileInfo { get; set; }
    }
}