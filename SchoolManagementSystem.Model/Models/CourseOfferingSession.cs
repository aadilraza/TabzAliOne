using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class CourseOfferingSession
    {
        public CourseOfferingSession()
        {
            AttendanceList = new List<Attendance>();
        }
        public int Id { get; set; }
        public int CourseOfferingId { get; set; }
        public virtual CourseOffering CourseOffering { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Attendance> AttendanceList { get; set; }
        public bool Canceled { get; set; }
    }
}
