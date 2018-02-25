using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagmentMvc.Abstract;
using UserManagmentMvc.EF.Entities;
using UserManagmentMvc.Models.ViewModel;
using UserManagmentMvc.Repositories;

namespace UserManagmentMvc.Services
{
    public  class UserService
    {
        private BaseRepository<User> repo;

        public UserService()
        {
            repo = new UserRepository();
        }

        public async Task<List<UserVM>> GetUsersList()
        {
            List<UserManagmentMvc.Models.ViewModel.UserVM> result = null;
            
            var res = (await repo.GetListAsync())
                .Select(x=> new UserVM {
                    ID = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    MidleName = x.Patronymic
                }).ToList();          

            return res;
        }
    }
}