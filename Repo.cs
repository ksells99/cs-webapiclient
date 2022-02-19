using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository
    {
        // Map "name" in json to Name string
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}