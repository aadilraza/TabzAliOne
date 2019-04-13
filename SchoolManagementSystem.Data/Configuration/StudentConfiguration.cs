using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class StudentConfiguration: EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Map(m =>
            {
                m.ToTable("Students");
            });
        }
    }
}
