using Microsoft.EntityFrameworkCore;

namespace SellWise.Infrastructure.Repository
{
    public interface IRepository
    {
        public IQueryable<T> All<T>();

        public IQueryable<T> AllAsReadOnly<T>();

        public  Task AddAsync<T>(T entity);

        public  Task<T?> GetByIdAsync<T>(object id);

        public  Task<int> SaveChangesAsync();
    }
}
