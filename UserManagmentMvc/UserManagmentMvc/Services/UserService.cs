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
    public class UserService
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
                .Select(x => new UserVM
                {
                    ID = x.Id,
                    Name = x.Name,
                    LastName = x.Surname,
                    MidleName = x.Patronymic
                }).ToList();

            return res;
        }

        public async Task<UserVM> GetUser(int userID)
        {
            if (userID > 0)
            {
                var user = (await repo.GetItemAsync(userID));

                return new UserVM()
                {
                    ID = user.Id,
                    Name = user.Name,
                    LastName = user.Surname,
                    MidleName = user.Patronymic
                };
            }
            else
            {
                return new UserVM();
            }
        }

        public bool CreateUser(UserVM userVM)
        {
            User user = new User()
            {
                Id = userVM.ID,
                Name = userVM.Name,
                Surname = userVM.LastName,
                Patronymic = userVM.MidleName,
                Employed = userVM.IsEmployed,
                OrganisationName = userVM.OrganisationName,
                phoneNumber = userVM.PhoneNumber,
                StartOnUTc = userVM.StartOnUTc
            };

            try
            {
                repo.Create(user);
                repo.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(UserVM userVM)
        {
            // TODO synhronus version 
            bool result = false;

            User user = new User()
            {
                Id = userVM.ID,
                Name = userVM.Name,
                Surname = userVM.LastName,
                Patronymic = userVM.MidleName,
                Employed = userVM.IsEmployed,
                OrganisationName = userVM.OrganisationName,
                phoneNumber = userVM.PhoneNumber,
                StartOnUTc = userVM.StartOnUTc

            };

            if (userVM.ID > 0)
            {
                repo.Update(user);
            }
            else
            {
                repo.Create(user);
            }


            repo.Save();
            return result;
        }


        public UserVM GetUserSync(int userID)
        {
            if (userID > 0)
            {
                var user = (repo.GetItem(userID));

                return new UserVM()
                {
                    ID = user.Id,
                    Name = user.Name,
                    LastName = user.Surname,
                    MidleName = user.Patronymic,
                    IsEmployed  = user.Employed,
                    OrganisationName = user.OrganisationName,
                    PhoneNumber = user.phoneNumber,
                    StartOnUTc = user.StartOnUTc
                };
            }
            else
            {
                return new UserVM();
            }
        }

        public bool Delete(int userID)
        {
            try
            {
                repo.Delete(userID);
                repo.Save();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public bool ExistUser(int userID)
        {
            return repo.GetItem(userID) != null;
        }
    }
}