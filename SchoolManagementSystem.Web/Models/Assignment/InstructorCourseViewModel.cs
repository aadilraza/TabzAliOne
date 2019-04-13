using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Models.Assignment
{
    public class InstructorCourseViewModel
    {
        public IEnumerable<SelectListItem> Instructors { get; set; }
        public int InstructorId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
        public int CourseId { get; set; }
    }
}