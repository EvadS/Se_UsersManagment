using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Models
{
    public class UserVM
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required field")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required field")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle Name is required field")]
        public string MidleName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required field ")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile. Number should be is 10 digits.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Is employed")]
        public bool IsEmployed { get; set; }

        [Display(Name = "Organisation name")]
        public string OrganisationName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Employment date")]
        public DateTime StartOnUTc { get; set; }

        public UserVM()
        {
            StartOnUTc = DateTime.Now;
        }              
    }
}
