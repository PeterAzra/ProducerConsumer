using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProducerConsumerApp.Core.MockDataFactory;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Infrastructure.API
{
    public class MockDataHttpDelegatingHandler(IServiceProvider serviceProvider) : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jsonData = GetResponseContent(request);
            var resp = new HttpResponseMessage
            {
                Content = new StringContent(jsonData),
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return Task.FromResult(resp);
        }

        private string GetResponseContent(HttpRequestMessage request)
        {
            var endpoint = request.RequestUri.PathAndQuery;
            var method = request.Method;

            if (endpoint.EndsWith("tribbles", StringComparison.InvariantCultureIgnoreCase) && method == HttpMethod.Get)
            {
                var dataFactory = serviceProvider.GetService<ICreateMockData<Tribble>>();
                var data = dataFactory.Create();
                return JsonSerializer.Serialize(data);
            }
            
            return string.Empty;
        }
    }
}