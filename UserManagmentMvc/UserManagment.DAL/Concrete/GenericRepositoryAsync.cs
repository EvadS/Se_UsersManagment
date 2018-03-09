using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagment.DAL.Abstract;
using UserManagment.DataEntities;

using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;



namespace UserManagment.DAL.Concrete
{
    public abstract class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly Lazy<Guid> _guid = new Lazy<Guid>(() => Guid.NewGuid());

        protected DbContext dbContext;
        protected DbSet<T> DbSet;
        protected ObjectContext ObjectContext;
        protected ObjectSet<T> ObjectSet;
        private bool disposed = false;

        public ObjectContext CoreObjectContext
        {
            get { return ((IObjectContextAdapter)dbContext).ObjectContext; }
        }

        public GenericRepositoryAsync(IDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Context cannot be null");
            }

            dbContext = context as DbContext;

            if (dbContext != null)
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                DbSet = dbContext.Set<T>();

                ObjectSet = CoreObjectContext.CreateObjectSet<T>();
            }
        }


        public T Add(T entity)
        {
            ObjectSet.AddObject(entity);
            Save();
            return entity;
        }

        public async Task<T> AddAsyn(T t)
        {
            dbContext.Set<T>().Add(t);
            await dbContext.SaveChangesAsync();
            return t;
        }


        public async Task<int> AddAsync(T t)
        {
            dbContext.Set<T>().Add(t);
            return await dbContext.SaveChangesAsync();
        }



        public int Count()
        {
            return dbContext.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Set<T>().CountAsync();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public async Task<int> DeleteAsyn(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbContext.Set<T>().Where(predicate);
            return query;
        }

        public async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }


        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public T Update(T updated, object key)
        {
            if (updated == null)
                return null;

            T existing = dbContext.Set<T>().Find(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
                dbContext.SaveChanges();
            }
            return existing;
        }

        public async Task<T> UpdateAsyn(T updated, object key)
        {
            if (updated == null)
                return null;

            T existing = await dbContext.Set<T>().FindAsync(key);
            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(updated);
                await dbContext.SaveChangesAsync();
            }
            return existing;
        }


        public async Task<ICollection<T>> GetAllAsyncs()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       async Task<bool> IGenericRepositoryAsync<T>.AddAsync(T t)
        {
            dbContext.Set<T>().Add(t);

            int rese = await dbContext.SaveChangesAsync();
            return rese > 0;
        }
    }

}
