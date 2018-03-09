using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.DAL.Abstract;
using UserManagment.DataEntities;
using UserManagment.DataEntities.Entities;

namespace UserManagment.DAL.Concrete
{
 
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(IDbContext dbContextInterface) : base(dbContextInterface)
        {
            Debug.WriteLine("AccountTypeRepository() Hash:" + GetHashCode());
        }
    }
}
