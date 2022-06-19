using Newtonsoft.Json;
using System;

namespace SmooveAPI
{
    public partial class Tenant
    {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supportContact")]
        public string SupportContact { get; set; }

        [JsonProperty("supportEmail")]
        public string SupportEmail { get; set; }

        [JsonProperty("billingContact")]
        public string BillingContact { get; set; }

        [JsonProperty("billingEmail")]
        public string BillingEmail { get; set; }

        [JsonProperty("showEvents")]
        public bool ShowEvents { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}