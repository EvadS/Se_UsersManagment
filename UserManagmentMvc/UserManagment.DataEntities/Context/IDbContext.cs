﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UserManagment.DataEntities
{
    public interface IDbContext
    {
        DbChangeTracker ChangeTracker { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;     
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        void Rollback();
    }
}
