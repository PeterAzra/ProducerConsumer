using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.API;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services.Default
{
    public class DataProducer<T>(ICreatureApi<T> api) : IDataProducer<T> where T : CreatureBase
    {
        public async Task<int> ProduceAsync(ChannelWriter<T> channelWriter)
        {
            var data = await api.GetAsync();
            foreach (var item in data)
            {
                await channelWriter.WriteAsync(item);
            }
            channelWriter.Complete();
            return data.Count();
        }
    }
}