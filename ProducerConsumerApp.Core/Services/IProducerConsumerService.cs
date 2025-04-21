using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Services
{
    public interface IProducerConsumerService<T> where T : CreatureBase
    {
        Task ExecuteAsync();
    }
}