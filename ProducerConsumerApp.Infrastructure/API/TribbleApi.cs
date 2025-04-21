using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.API;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Infrastructure.API
{
    public class TribbleApi(IHttpClientFactory httpClientFactory) : ICreatureApi<Tribble>
    {
        private const string ApiEndpoint = "/api/tribbles";

        public async Task<IEnumerable<Tribble>> GetAsync()
        {
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            var response = await httpClient.GetAsync(ApiEndpoint);
            return await response.Content.ReadFromJsonAsync<IEnumerable<Tribble>>();
        }

        public async Task<IEnumerable<Tribble>> UpdateAsync(IEnumerable<Tribble> itemsToUpdate)
        {
            var httpClient = httpClientFactory.CreateClient("ApiClient");
            var body = new StringContent(JsonSerializer.Serialize(itemsToUpdate));
            var response = await httpClient.PostAsync(ApiEndpoint, body);
            return itemsToUpdate;
        }
    }
}