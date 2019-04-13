namespace SchoolManagementSystem.Model.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public bool Attended { get; set; }
        public int CourseOfferingSessionId { get; set; }
        public virtual CourseOfferingSession CourseOfferingSession { get; set; }
    }
}
