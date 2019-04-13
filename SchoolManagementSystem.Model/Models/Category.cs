using System.Collections.Generic;

namespace SchoolManagementSystem.Model.Models
{
    public class Category
    {
        public Category()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desription { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
