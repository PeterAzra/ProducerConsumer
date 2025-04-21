using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.API;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services.Default
{
    public class DataConsumer<T>(ICreatureApi<T> api) : IDataConsumer<T> where T : CreatureBase
    {
        public async Task<int> ConsumeAsync(ChannelReader<T> channelReader)
        {
            int totalCount = 0;
            while (await channelReader.WaitToReadAsync())
            {
                var itemsToUpdate = new List<T>();
                await foreach (var item in channelReader.ReadAllAsync())
                {
                    itemsToUpdate.Add(item);
                }
                await api.UpdateAsync(itemsToUpdate);
                totalCount += itemsToUpdate.Count();
            }
            return totalCount;
        }
    }
}