using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Web.Models.Person.Student
{
    public class StudentDetailsViewModel:PersonDetailsViewModel
    {
        public bool IsCorporate { get; set; }
    }
}