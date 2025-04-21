using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services
{
    public interface IDataProducer<T> where T : CreatureBase
    {
        Task<int> ProduceAsync(ChannelWriter<T> channelWriter);
    }
}