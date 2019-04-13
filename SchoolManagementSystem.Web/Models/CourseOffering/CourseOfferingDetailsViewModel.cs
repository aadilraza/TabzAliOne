using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Web.Models.CourseOffering
{
    public class CourseOfferingDetailsViewModel: CourseOfferingViewModel
    {
        public IEnumerable<SelectListItem> Courses { get; set; }
        public int CourseId { get; set; }
        /// <summary>
        /// Hourly rate of instructor
        /// </summary>
        [Range(0,int.MaxValue)]
        public int HourlyRate { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; set; }
        public int RoomId { get; set; }
        public IEnumerable<SelectListItem> Instructors { get; set; }
        public int InstructorId { get; set; }
    }
}