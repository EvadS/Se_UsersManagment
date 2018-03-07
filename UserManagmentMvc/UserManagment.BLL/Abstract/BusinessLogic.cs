using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Models;

namespace UserManagment.BLL.Abstract
{
    public interface IBusinessLogic
    {
        List<UserVM> GetUsersList();
    }
}
