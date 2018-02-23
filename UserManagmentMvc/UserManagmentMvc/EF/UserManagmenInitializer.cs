using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserManagmentMvc.EF
{
    public class UserManagmenInitializer : CreateDatabaseIfNotExists<UserManagmentContext>
    {
        protected override void Seed(UserManagmentContext db)
        {
            // TODO : for dev 
          
        }
    }
}