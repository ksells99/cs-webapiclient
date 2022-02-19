using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        // Returns a task whose result is a list of Repository objects
        private static async Task<List<Repository>> ProcessRepositories()
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
            
            // var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            // var msg = await stringTask;
            // Console.Write(msg);

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

            // Deserialise json response into a list of objects containing only what is in Repository class (Repo.cs)
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);


            return repositories;


        }
        
        
        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();
            
            foreach(Repository repo in repositories)
            {
                Console.WriteLine(repo.Name);
            }
        }
    }
}
