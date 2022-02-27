using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace OnboardingRepository.BaseRepo
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected OnboardingDemoContext dbContext;
        private readonly DbSet<T> dbSet;
        public int saveCount;

        public BaseRepository(OnboardingDemoContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.Entry(entity).State = EntityState.Added;
        }

        public async Task<bool> AddAsync(T entity)
        {
            dbSet.Add(entity);
            dbContext.Entry(entity).State = EntityState.Added;
            return await SaveAsync();
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            saveCount = await Task.FromResult(this.dbContext.SaveChanges());
            return saveCount > 0;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await Task.FromResult(this.dbSet.Where(filter).AsQueryable<T>());
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Task.FromResult(this.dbSet.AsQueryable().FirstOrDefault(filter));
        }

        public async Task<bool> SaveAsync()
        {
            saveCount = await this.dbContext.SaveChangesAsync();
            return saveCount > 0;
        }

        public   bool Save()
        {
            saveCount =  this.dbContext.SaveChanges();
            return saveCount > 0;
        }
    }
}
