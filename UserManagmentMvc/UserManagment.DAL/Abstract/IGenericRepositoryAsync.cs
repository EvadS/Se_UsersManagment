using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.DAL.Abstract
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        T Add(T t);
        Task<T> AddAsyn(T t);
        Task<bool> AddAsync(T t);
        int Count();
        Task<int> CountAsync();
        void Delete(T entity);
        Task<int> DeleteAsyn(T entity);
        void Dispose();
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsyncs();
        Task<ICollection<T>> GetAllAsyncs(int currentPage, int num );
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
      
        T Update(T t, object key);
        Task<T> UpdateAsyn(T t, object key);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int skip = 0, int takesNum = 0, params Expression<Func<T, object>>[] includeProperties);



        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int skip, int takesNum, params Expression<Func<T, object>>[] includeProperties);


    }
}
