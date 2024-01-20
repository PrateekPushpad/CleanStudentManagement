using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.Repository
{
    public interface IGenericRepository<T>: IDisposable
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter=null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null,
             string includeProperties=null);

        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void DeleteById(int id);
        Task<T> DeleteAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> UpdateAsync(T entity);

    }
}
