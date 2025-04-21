using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Stores
{
    public interface ICreatureStore<T> where T : CreatureBase
    {
        Task<IEnumerable<T>> GetAsync();
    }
}