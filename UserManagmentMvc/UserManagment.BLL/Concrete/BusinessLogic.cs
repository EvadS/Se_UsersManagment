using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.BLL.Abstract;
using UserManagment.DAL.Abstract;
using UserManagment.DAL.Concrete;
using UserManagment.Models;

namespace UserManagment.BLL.Concrete
{
   public  class BusinessLogic: GenericBusinessLogic, IBusinessLogic
    {
        private readonly IUserRepository _userRepository;
              

        // TODO: have to replace with ninject 
        public BusinessLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public  List<UserVM> GetUsersList()
        {
            List<UserVM> result = null;

            var res = ( _userRepository.GetAll())
                .Select(x => new UserVM
                {
                    ID = x.Id,
                    Name = x.Name,
                    LastName = x.Surname,
                    MidleName = x.Patronymic
                }).ToList();

            return res;
        }
    }
}
