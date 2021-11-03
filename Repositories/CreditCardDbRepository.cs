using Microsoft.EntityFrameworkCore;
using NordicStationCodeTestPart3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NordicStationCodeTestPart3.Repositories
{
    public class CreditCardDbRepository<T> : ICreditCardDbRepository<T> where T : class
    {
        private readonly CreditCardDbContext context;
        private DbSet<T> entities;

        public CreditCardDbRepository(CreditCardDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            entities.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
