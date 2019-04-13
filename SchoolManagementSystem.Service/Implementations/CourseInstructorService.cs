using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using SchoolManagementSystem.Data.Repository.Interfaces;
using SchoolManagementSystem.Service.Interfaces;

namespace SchoolManagementSystem.Service.Implementations
{
    public class CourseInstructorService : ICourseInstructorService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseInstructorService( ICourseRepository courseRepository, IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }
        public void AssignInstructorToCourse(int instructorId, int courseId)
        {
            var instructor = _instructorRepository.GetById(instructorId);
            var course = _courseRepository.GetById(courseId);
            instructor.Courses.Add(course);
            SaveCourseInstructor();
        }

        public void DivestInstructorFromCourse(int instructorId, int courseId)
        {
            var instructor = _instructorRepository.GetById(instructorId);
            var course = _courseRepository.GetById(courseId);
            instructor.Courses.Remove(course);
            SaveCourseInstructor();
        }
        private void SaveCourseInstructor()
        {
            _unitOfWork.Commit();
        }
    }
}
