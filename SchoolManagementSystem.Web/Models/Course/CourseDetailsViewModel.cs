using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Models.Course
{
    public class CourseDetailsViewModel:CourseViewModel
    {
        public int Duration { get; set; }
        public string Category { get; set; }
        public IEnumerable<SelectList> SubCourses { get; set; }
        public IEnumerable<int> SelectedSubCourses { get; set; }
    }
}