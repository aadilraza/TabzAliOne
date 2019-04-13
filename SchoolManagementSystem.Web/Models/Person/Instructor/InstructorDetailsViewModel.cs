﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Web.Models.Person.Instructor
{
    public class InstructorDetailsViewModel:PersonDetailsViewModel
    {
        public InstructorDetailsViewModel()
        {
            Courses = new List<CheckBoxListItem>();
        }
        public IEnumerable<CheckBoxListItem> Courses { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
    }
}