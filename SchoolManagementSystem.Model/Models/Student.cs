using SchoolManagementSystem.Model.Models.Abstractions;
using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class Student:Person
    {
        public Student()
        {
            CourseOfferings = new List<CourseOffering>();
        }
        public bool IsCorporate { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
    }
}
