using Microsoft.EntityFrameworkCore;

namespace SellWise.Infrastructure.Repository
{
    public interface IRepository
    {
        public IQueryable<T> All<T>() where T : class;

        public IQueryable<T> AllAsReadOnly<T>() where T : class;

        public  Task AddAsync<T>(T entity) where T : class;

        public  Task<T?> GetByIdAsync<T>(object id) where T : class;

        public  Task<int> SaveChangesAsync();
    }
}
