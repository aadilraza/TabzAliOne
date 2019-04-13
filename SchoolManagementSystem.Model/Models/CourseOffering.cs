using SchoolManagementSystem.Model.Enums;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class CourseOffering
    {
        public CourseOffering()
        {
            Students = new List<Student>();
            CourseOfferingSessions = new List<CourseOfferingSession>();
            State = CourseOfferingState.Waiting;
            //Days = new HashSet<Days>();
        }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int HoursElapsed { get; set; }
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        /// <summary>
        /// Hourly rate of instructor
        /// </summary>
        public int HourlyRate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<CourseOfferingSession> CourseOfferingSessions { get; set; }
        public CourseOfferingState State { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public virtual Days Days { get; set; }

    }
}
