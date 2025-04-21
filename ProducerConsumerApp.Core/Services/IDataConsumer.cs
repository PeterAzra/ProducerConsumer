using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services
{
    public interface IDataConsumer<T> where T : CreatureBase
    {
        Task<int> ConsumeAsync(ChannelReader<T> channelReader);
    }
}