using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagmentMvc.Models.ViewModel
{
    public class UserVM
    {
        public int ID { get; set; }

        [Required]      
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Display(Name = "Middle Name")]
        public string MidleName { get; set; }

        public UserVM()
        {

        }

        public UserVM(UserManagmentMvc.EF.Entities.User user )
        {
            this.ID = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
        }


    }

   
}