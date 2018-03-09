using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UserManagment.BLL.Abstract;
using UserManagment.DAL.Abstract;
using UserManagment.DataEntities.Entities;
using UserManagment.Models;

namespace UserManagment.BLL.Concrete
{
    public class UserService : GenericBusinessLogic, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserVM> GetUsersList()
        {
            var res = (_userRepository.GetAll())
                .Select(x => new UserVM
                {
                    ID = x.Id,
                    Name = x.Name,
                    LastName = x.Surname,
                    MidleName = x.Patronymic
                }).ToList();

            return res;
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
                _userRepository.Add(user);
                        return true;
            }
            catch (Exception ex)
            {
                //TODO: nedd to add logger
                return false;
            }
        }

        public bool UpdateUser(UserVM userVM)
        {
            try
            {
                var user = _userRepository.Find(x => x.Id == userVM.ID).FirstOrDefault();

                if (user == null)
                    return false;

                user.Name = userVM.Name;
                user.Surname = userVM.LastName;
                user.Patronymic = userVM.MidleName;
                user.Employed = userVM.IsEmployed;
                user.OrganisationName = userVM.OrganisationName;
                user.phoneNumber = userVM.PhoneNumber;
                user.StartOnUTc = userVM.StartOnUTc;

                _userRepository.ChangeState(user, EntityState.Modified);
                return true;
            }
            catch (Exception ex)
            {
                // TODO: add logger 
                return false;
            }
        }

        public UserVM GetUser(int userID)
        {
            try
            {
                var user = _userRepository.Find(x => x.Id == userID).FirstOrDefault();

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
            catch (Exception ex)
            {
                // TODO: add logger 
                return null;
            }
        }

        public bool DeleteUser(int userID)
        {
            var userEntity = _userRepository.Find(x => x.Id == userID).FirstOrDefault();

            if (userEntity == null)
                return false;

            _userRepository.Delete(userEntity);
            _userRepository.Save();

            return true;
        }

        public bool ExistsUser(int userID)
        {
            return  _userRepository.Find(x => x.Id == userID).FirstOrDefault()!= null;
        }     
    }
}
