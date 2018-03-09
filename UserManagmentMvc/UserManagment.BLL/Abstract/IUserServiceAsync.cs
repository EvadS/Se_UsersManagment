using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Models;

namespace UserManagment.BLL.Abstract
{
    public  interface IUserServiceAsync
    {
        Task<List<UserVM>> GetUsersList();
        Task<bool> CreateUser(UserVM userVM);
        Task<bool> UpdateUser(UserVM userVM);
        Task<UserVM> GetUser(int userID);
        Task<bool> DeleteUser(int userID);
        Task<bool> ExistsUser(int userID);
    }
}
