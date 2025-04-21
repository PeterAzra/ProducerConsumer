using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.MockDataFactory
{
    public interface ICreateMockData<T> where T : CreatureBase
    {
        IEnumerable<T> Create();
    }
}