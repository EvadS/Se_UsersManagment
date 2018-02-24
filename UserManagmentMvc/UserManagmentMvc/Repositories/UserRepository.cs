﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagmentMvc.Abstract;
using UserManagmentMvc.EF;
using UserManagmentMvc.EF.Entities;

namespace UserManagmentMvc.Repositories
{
    public class UserRepository : BaseRepository<User>
    {

        private UserManagmentContext db;
        private bool disposed = false;

        public UserRepository()
        {
            db = new UserManagmentContext();
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }

        public User GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetList()
        {
            return db.Users.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            return await db.Users.ToListAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}