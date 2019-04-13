using SchoolManagementSystem.Data.Infrastructure.Abstractions;
using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Model.Models;

namespace SchoolManagementSystem.Data.Repository.Implementations
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }      
    }
}
