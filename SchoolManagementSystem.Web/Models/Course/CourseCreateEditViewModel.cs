using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Models.Course
{
    public class CourseCreateEditViewModel:CourseViewModel
    {
        public int Duration { get; set; }
        //public string Category { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}