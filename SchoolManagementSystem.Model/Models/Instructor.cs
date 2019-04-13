using SchoolManagementSystem.Model.Models.Abstractions;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class Instructor:Person
    {
        public Instructor()
        {
            Courses = new List<Course>();
            CourseOfferings = new List<CourseOffering>();
            AvailableDays = new HashSet<DayOfWeek>();
        }
        public DateTime? HireDate { get; set; }
        //public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
        public virtual ICollection<DayOfWeek> AvailableDays { get; set; }
    }
}
