using InventoryControl.Domain.Models;

namespace InventoryControl.Domain.Repositories
{
    public interface IRepositoryBase
    {
        public Task AddAsync<T>(T entity) where T : class;        

    }
}