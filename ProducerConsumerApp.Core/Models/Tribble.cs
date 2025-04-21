using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducerConsumerApp.Core.Models
{
    public record class Tribble(int Id, string Name, string Color) : CreatureBase
    {
        
    }
}