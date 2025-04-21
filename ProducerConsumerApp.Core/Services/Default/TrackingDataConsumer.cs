using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;
using ProducerConsumerApp.Core.Repository;

namespace ProducerConsumerApp.Core.Services.Default
{
    public class TrackingDataConsumer<T>(ICreatureRepository<T> repo) : ITrackingDataConsumer<T> where T : CreatureBase
    {
        public async Task<int> ExecuteAsync(ChannelReader<T> channelReader, ChannelWriter<T> channelWriter)
        {
            int totalCount = 0;
            while (await channelReader.WaitToReadAsync())
            {
                var itemsToAdd = new List<T>();
                await foreach (var item in channelReader.ReadAllAsync())
                {
                    itemsToAdd.Add(item);
                }

                var createdItems = await repo.CreateAsync(itemsToAdd);

                foreach (var created in createdItems)
                {
                    await channelWriter.WriteAsync(created);
                }
                totalCount += itemsToAdd.Count;
            }
            
            channelWriter.Complete();
            return totalCount;
        }
    }
}