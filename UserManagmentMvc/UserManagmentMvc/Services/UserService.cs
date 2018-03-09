﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagment.DataEntities.Entities;
using UserManagment.Models;
using UserManagmentMvc.Abstract;

using UserManagmentMvc.Repositories;

namespace UserManagmentMvc.Services
{
    public class UserService
    {
        private BaseRepository<User> repo;

       /*

        public async Task<List<UserVM>> GetUsersListAsync()
        {
            List<UserVM> result = null;

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

        public async Task<UserVM> GetUserAsync(int userID)
        {
            if (userID > 0)
            {
                var user = (await repo.GetItemAsync(userID));

                return new UserVM()
                {
                    ID = user.Id,
                    Name = user.Name,
                    LastName = user.Surname,
                    MidleName = user.Patronymic,
                    IsEmployed = user.Employed,
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

        public async Task<bool> CreateUserAsync(UserVM userVM)
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
                var res = await repo.SaveAsync();
                return res > 0;
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

        public async Task<bool> UpdateUserAsync(UserVM userVM)
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

            if (userVM.ID > 0)
            {
                repo.Update(user);
            }
            else
            {
                repo.Create(user);
            }

            var operationResult = await repo.SaveAsync();
            return operationResult > 0;
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
                    IsEmployed = user.Employed,
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

        public async Task<bool> DeleteAsync(int userID)
        {
            try
            {
                repo.Delete(userID);
                await repo.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<bool> ExistUser(int userID)
        {
            return await repo.GetItemAsync(userID) != null;
        }*/
    }
}