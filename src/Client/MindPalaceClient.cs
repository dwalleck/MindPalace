using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MindPalace.Shared.Dtos;

namespace MindPalace.Client
{
    public class MindPalaceClient
    {
        private readonly HttpClient Client;

        public MindPalaceClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task<List<LinkDto>> GetLinks()
        {
            var links = await Client.GetFromJsonAsync<List<LinkDto>>("/api/links");
            return links;
        }
    }

}