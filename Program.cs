using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task ProcessRepositories()
        {
            // Set up HTTP headers
            client.DefaultRequestHeaders.Accept.Clear();
            // Accept json responses
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            // This header gets checked by Github 
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            // Fetch data from Github api
            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var msg = await stringTask;
            Console.Write(msg);
        }
        
        
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
    }
}
