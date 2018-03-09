using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using UserManagment.DataEntities.Entities;

namespace UserManagment.DataEntities
{
    public class UserManagmentContext : DbContext, IDbContext
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
