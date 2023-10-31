using InventoryControl.Domain.Models;
using InventoryControl.Domain.Repositories;
using InventoryControl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Application.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly DatabaseContext _context;
        public RepositoryBase(DatabaseContext context){
            _context = context;
        }

        public Task AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();    
        }
    }
}