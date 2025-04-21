using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services.Default
{
    public class TribbleProducerConsumerService(IDataProducer<Tribble> producer, 
        ITrackingDataConsumer<Tribble> trackingConsumer, 
        IDataConsumer<Tribble> consumer) : IProducerConsumerService<Tribble>
    {
        public Task ExecuteAsync()
        {
            var producerChannel = Channel.CreateBounded<Tribble>(100);
            var trackingChannel = Channel.CreateBounded<Tribble>(100);

            var producerTask = producer.ProduceAsync(producerChannel.Writer);
            var trackingTask = trackingConsumer.ExecuteAsync(producerChannel.Reader, trackingChannel.Writer);
            var consumerTask = consumer.ConsumeAsync(trackingChannel.Reader);

            Task.WaitAll(producerTask, trackingTask, consumerTask);
            return Task.CompletedTask;
        }
    }
}