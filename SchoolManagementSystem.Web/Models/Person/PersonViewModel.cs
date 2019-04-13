using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Web.Models.Person
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^(05)[0-9][0-9]([0-9]){7}$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}