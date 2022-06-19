using Newtonsoft.Json;
using System;

namespace SmooveAPI
{
    public partial class Interface
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty("group")]
        public Guid Group { get; set; }

        [JsonProperty("company")]
        public object Company { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sdlcStatus")]
        public string SdlcStatus { get; set; }

        [JsonProperty("combinedStatus")]
        public object CombinedStatus { get; set; }

        [JsonProperty("health")]
        public string Health { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("managementUrl")]
        public Uri ManagementUrl { get; set; }

        [JsonProperty("archiveUrl")]
        public Uri ArchiveUrl { get; set; }

        [JsonProperty("archiving")]
        public bool Archiving { get; set; }

        [JsonProperty("managementTokenDetails")]
        public TokenDetails ManagementTokenDetails { get; set; }

        [JsonProperty("archiveTokenDetails")]
        public TokenDetails ArchiveTokenDetails { get; set; }

    }
}