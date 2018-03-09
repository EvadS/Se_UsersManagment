using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.BLL.Abstract;
using UserManagment.DAL.Abstract;
using UserManagment.DataEntities.Entities;
using UserManagment.Models;

namespace UserManagment.BLL.Concrete
{
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync _userRepository;
        public UserServiceAsync(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(UserVM userVM)
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
                var newUser = await _userRepository.AddAsync(user);

                if (newUser)
                {
                    var res = await _userRepository.SaveAsync();
                    return res >= 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int userID)
        {
            try
            {
                var user =  await _userRepository.GetAsync(userID);

                if (user == null)
                    return false;

                int res = await  _userRepository.DeleteAsyn(user);
                await _userRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistsUser(int userID)
        {
            return await _userRepository.GetAsync(userID) != null;
        }

        public async Task<UserVM> GetUser(int userID)
        {
            if (userID > 0)
            {
                var user = (await _userRepository.GetAsync(userID));

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

        public async Task<List<UserVM>> GetUsersList()
        {
            var res = (await _userRepository.GetAllAsyncs())
               .Select(x => new UserVM
               {
                   ID = x.Id,
                   Name = x.Name,
                   LastName = x.Surname,
                   MidleName = x.Patronymic
               }).ToList();

            return res;
        }

        public async Task<bool> UpdateUser(UserVM userVM)
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
                await _userRepository.UpdateAsyn(user, userVM.ID);
            }
            else
            {
                await _userRepository.AddAsync(user);
            }

            var operationResult = await _userRepository.SaveAsync();
            return operationResult > 0;
        }
    }
}
