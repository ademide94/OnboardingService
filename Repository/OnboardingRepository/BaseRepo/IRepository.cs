using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingRepository.BaseRepo
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task<bool> AddAsync(T entity);

        Task<bool> Update(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        bool Save();
    }
}
