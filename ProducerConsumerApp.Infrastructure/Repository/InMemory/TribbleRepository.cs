using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.MockDataFactory;
using ProducerConsumerApp.Core.Models;
using ProducerConsumerApp.Core.Repository;

namespace ProducerConsumerApp.Infrastructure.Repository.InMemory
{
    public class TribbleRepository() : ICreatureRepository<Tribble>
    {
        private List<Tribble> _data = new List<Tribble>();
        public Task<IEnumerable<Tribble>> GetAsync()
        {
            return Task.FromResult(_data.AsEnumerable());
        }

        public Task<IEnumerable<Tribble>> CreateAsync(IEnumerable<Tribble> toAdd)
        {
            _data.AddRange(toAdd);
            return Task.FromResult(toAdd);
        }
    }
}