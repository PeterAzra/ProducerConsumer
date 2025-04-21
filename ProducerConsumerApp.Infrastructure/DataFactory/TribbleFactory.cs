using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.MockDataFactory;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Infrastructure.DataFactory
{
    public class TribbleFactory : ICreateMockData<Tribble>
    {
        public IEnumerable<Tribble> Create()
        {
            return new List<Tribble>
            {
                new Tribble(1, "Barney", "Black"),
                new Tribble(2, "Rooster", "White"),
                new Tribble(3, "King", "Grey"),
            };
        }
    }
}