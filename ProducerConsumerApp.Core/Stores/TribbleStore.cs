using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.MockDataFactory;
using ProducerConsumerApp.Core.Models;
using ProducerConsumerApp.Core.Repository;

namespace ProducerConsumerApp.Core.Stores
{
    public class TribbleStore(ICreatureRepository<Tribble> repo) : ICreatureStore<Tribble>
    {
        public Task<IEnumerable<Tribble>> GetAsync()
        {
            return repo.GetAsync();
        }
    }
}