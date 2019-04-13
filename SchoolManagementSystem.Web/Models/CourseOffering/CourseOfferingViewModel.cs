using SchoolManagementSystem.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace SchoolManagementSystem.Web.Models.CourseOffering
{
    public class CourseOfferingViewModel
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public int HoursElapsed { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public string Instructor { get; set; }
        public string Course { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan EndTime { get; set; }
        public virtual Days Days { get; set; }
        public int StudentsCount { get; set; }
        public CourseOfferingState State { get; set; }
    }
}