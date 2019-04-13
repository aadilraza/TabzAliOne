using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Web.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        public override string ToString() => Title;
    }
}