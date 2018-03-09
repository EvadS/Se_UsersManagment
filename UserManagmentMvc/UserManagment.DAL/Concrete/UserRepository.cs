using System.Diagnostics;
using UserManagment.DAL.Abstract;
using UserManagment.DataEntities;
using UserManagment.DataEntities.Entities;
namespace UserManagment.DAL.Concrete
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContextInterface) : base(dbContextInterface)
        {
            Debug.WriteLine("AccountTypeRepository() Hash:" + GetHashCode());
        }
    }

}
