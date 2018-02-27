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

        [Required]
        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MidleName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string phoneNumber { get; set; }

        [Display(Name = "Is employed")]
        public bool IsEmployed { get; set; }

        [Display(Name = "Organisation name")]
        public string OrganisationName { get; set; }

        [Display(Name= "Employment date")]
        [DataType(DataType.Date)]
        public DateTime StartOnUTc { get; set; }

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