using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Model.Models
{
    public class Course
    {
        public Course()
        {
            SubCourses = new List<Course>();
            Instructors = new List<Instructor>();
            Rooms= new List<Room>();
            IsActive = true;
            CourseOfferings = new List<CourseOffering>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Course Parent { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Course> SubCourses { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }

    }
}
