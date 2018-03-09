using System.Collections.Generic;
using UserManagment.Models;

namespace UserManagment.BLL.Abstract
{
    public interface IUserService
    {
        List<UserVM> GetUsersList();
        bool CreateUser(UserVM userVM);
        bool UpdateUser(UserVM userVM);
        UserVM GetUser(int userID);
        bool DeleteUser(int userID);
        bool ExistsUser(int userID);
    }
}
