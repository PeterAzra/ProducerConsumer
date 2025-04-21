using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services
{
    public interface ITrackingDataConsumer<T> where T : CreatureBase
    {
        Task<int> ExecuteAsync(ChannelReader<T> channelReader, ChannelWriter<T> channelWriter);
    }
}