using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.Repository
{
    public interface ICreatureRepository<T> where T : CreatureBase
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> CreateAsync(IEnumerable<T> toAdd);
    }
}