using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class Room
    {
        public Room()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public bool IsActive { get; set; }
    }
}
