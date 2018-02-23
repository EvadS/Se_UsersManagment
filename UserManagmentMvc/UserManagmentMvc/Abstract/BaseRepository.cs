using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UserManagmentMvc.Abstract
{
    public interface BaseRepository<T> : IDisposable where T : class
    {
        //получить все 
        IEnumerable<T> GetList();

        Task<IEnumerable<T>> GetListAsync();

        T GetItem(int id);

        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}