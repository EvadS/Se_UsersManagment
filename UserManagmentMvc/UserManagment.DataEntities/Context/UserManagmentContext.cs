using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.DataEntities.Entities;

namespace UserManagment.DataEntities
{
    class UserManagmentContext : DbContext, IDbContext
    {      

        public UserManagmentContext() : base("DbConnection")
        {
            OnInitialized();
        }

        public DbSet<User> Users { get; set; }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        void OnInitialized()
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;
        }
    }
}
