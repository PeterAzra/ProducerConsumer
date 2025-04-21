using ProducerConsumerApp.Core.Models;

namespace ProducerConsumerApp.Core.API
{
    public interface ICreatureApi<T> where T : CreatureBase
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> itemsToUpdate);
    }
}