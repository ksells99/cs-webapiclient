using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository
    {
        // Map "name" in json to Name property
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }

        // Create local lastPush time based on UTC property
        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}