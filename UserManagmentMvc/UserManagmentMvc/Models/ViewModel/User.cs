using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagmentMvc.Models.ViewModel
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public User(UserManagmentMvc.EF.Entities.User user )
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
        }
    }

   
}