using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserManagmentMvc.EF.Entities;

namespace UserManagmentMvc.EF
{
    public class UserManagmentContext: DbContext
    {
        static UserManagmentContext()
        {
            Database.SetInitializer(new UserManagmenInitializer());
        }

        public UserManagmentContext() : base("DbConnection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}