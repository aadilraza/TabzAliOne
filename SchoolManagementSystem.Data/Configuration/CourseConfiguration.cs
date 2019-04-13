using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(c => c.Duration).IsOptional();
            Property(c => c.Title).IsRequired();
            Property(c => c.Description).IsRequired();
        }
    }
}
