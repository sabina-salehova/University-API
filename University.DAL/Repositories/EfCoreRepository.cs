using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Base;
using University.DAL.DataContext;
using University.DAL.Repositories.Contracts;

namespace University.DAL.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext _dbContext;

        public EfCoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task AddAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null) throw new Exception();

            var deletedEntity = await _dbContext.Set<T>().FindAsync(id);

            if (deletedEntity == null) throw new Exception();

            _dbContext.Set<T>().Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null) throw new Exception();

            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
