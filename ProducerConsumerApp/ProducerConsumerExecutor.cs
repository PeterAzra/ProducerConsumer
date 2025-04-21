using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;
using ProducerConsumerApp.Core.Services;

namespace ProducerConsumerApp
{
    public class ProducerConsumerExecutor(IServiceProvider serviceProvider) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var creatureTypes = new List<Type>
            {
                typeof(Tribble)
            };

            foreach (var t in creatureTypes)
            {
                if (t == typeof(Tribble))
                {
                    var task = serviceProvider.GetRequiredService<IProducerConsumerService<Tribble>>();
                    await task.ExecuteAsync();
                }       
            }
        }
    }
}